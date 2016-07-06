﻿// Программа может одновременно записать и воспроизвезти звук, 
// выполнить запись .wav файла и построить осциллограмму вместе с выводом амлитуды левого и правого канала выше значения 0.5 

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NAudio.Wave; // внешняя библа NAudio

namespace AudioRecord
{
    
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint waveOutGetVolume(uint hwo, ref uint dwVolume);
        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern int waveOutSetVolume(uint uDeviceID, uint dwVolume);

        WaveIn _sourceStream; // Позволяет записывать, используя API-интерфейсы для Windows WaveIn
        DirectSoundOut _waveOut; // Аудиовыход
        WaveFileWriter _waveWriter; //Этот класс записывает данные в .wav файл на диске
        private string _path; // Переменная запоминающая путь сохранения .wav файла 

        SaveFileDialog _save = new SaveFileDialog();

        ArrayList _ampRight = new ArrayList();//Будем хранить значения амплитуды звука левого канала
        ArrayList _ampLeft = new ArrayList();//Будем хранить значения правого канала
        float _volumeRight;//Будем использовать для хранения каждого 2400 сэмпла
        float _volumeLeft;//Будем использовать для хранения каждого 2400 сэмпла
        ArrayList _counterRight = new ArrayList();//Будем хранить время/дискреты 
        ArrayList _counterLeft = new ArrayList();//Будем хранить время/дискреты
        
        TimeSpan _time;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.textBox;

            uint currVol; // По умолчанию установлена громкость 0
            waveOutGetVolume(IntPtr.Zero, out currVol); // В этой строке currVol получает назначение громкости
            ushort calcVol = (ushort) (currVol & 0x0000ffff); // Вычисление громкости 
            trackBar1.Value = calcVol/(ushort.MaxValue/10); // Получить громкость на шкале от 1 до 10 (по размеру TrackBar)

            timer1.Interval = 1000;
            timer1.Tick += (timer1_Tick);
        }
    
        //Кнопка отображающая устройства записи
        private void Sources_Click(object sender, EventArgs e)
        {
            //Список (List) WaveInCapabilities.Структура, которая может содержать wave данные устройства.
            List<WaveInCapabilities> sources = new List<WaveInCapabilities>();

            //Шагаем по устройствам в системе.
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                sources.Add(WaveIn.GetCapabilities(i));
            }

            sourceList.Items.Clear(); //ListView

            // Добавляем имена список устройств моему ListView.
            foreach (var source in sources)
            {
                ListViewItem item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                sourceList.Items.Add(item);
            }
        }

        // Кнопка записи звука с микрофона и отправляя его на выходной порт (воспроизведение)
        private void ListenToThisDevice_Click(object sender, EventArgs e)
        {
            if (sourceList.SelectedItems.Count == 0) return;
            int deviceNumber = sourceList.SelectedItems[0].Index;
            _sourceStream = new WaveIn();
            _sourceStream.DeviceNumber = deviceNumber;
            _sourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(deviceNumber).Channels);
            WaveInProvider waveIn = new WaveInProvider(_sourceStream);
            _waveOut = new DirectSoundOut();
            _waveOut.Init(waveIn);
            _sourceStream.StartRecording();
            _waveOut.Play();
        }

        
        private void Browse_Click(object sender, EventArgs e)
        {
            if (sourceList.SelectedItems.Count == 0) return;
            //Открываем SaveFileDialog для сохранения файла по заданному пути
            _save.Filter = @"Wave File (*.wav)|*.wav;";
            if (_save.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = _save.FileName;
        }

        //Кнопка производящая запись в .wav файл
        private void StartRecord_Click(object sender, EventArgs e)
        {
            _save.FileName = textBox1.Text;
            _path = Path.GetFullPath(_save.FileName); // Присваиваем переменной путь сохранения .wav файла 
            
                if (sourceList.SelectedItems.Count == 0) return;
                // Берем позицию устройства записи
                int deviceNumber = sourceList.SelectedItems[0].Index;
                // Подготавливаем _sourceStream к записи
                _sourceStream = new WaveIn();
                _sourceStream.DeviceNumber = deviceNumber;
                // new WaveFormat(Частота дискретизации; Получает количество каналов поддерживаемых на устройстве)
                _sourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(deviceNumber).Channels);

                _sourceStream.DataAvailable += sourceStream_DataAvailable;
            
            try
            {
                // new WaveFileWriter(Задает строку содержащую имя файла выбранное в диалоговом окне файла; Параметры звука в .wav файле что прописанны выше)
                _waveWriter = new WaveFileWriter(_save.FileName, _sourceStream.WaveFormat);
                //Старт записи
                _sourceStream.StartRecording();

                _time = new TimeSpan();
                timer1.Start();

                StartRecord.Enabled = false;

                _ampRight.Clear();
                _ampLeft.Clear();
                _counterRight.Clear();
                _counterLeft.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Файл занят другим процессом",@"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // В обработчике событий WaveIn.DataAvailable можно задействовать каждый отсчет, глядя на байты в e.Buffer
        // WaveInEventArgs содержит информацию о буфере, хранящий количестве записанных байтов e.Buffer
        // Я записываю в 16 бит, каждые 2 байта образуют один отсчет
        private void sourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_waveWriter == null) return;
            // Добавляет байты в wave файл, сохраняя их в буфер
            _waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            _waveWriter.Flush();
        }
        
        //Кнопка остановки записи и вывода осциллограмы посредством элемента управления Microsoft Chart
        private void StopRecord_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            // если переменная от DirectSoundOut не налл, то останавливаем воспроизведение
            if (_waveOut != null)
            {
                _waveOut.Stop();
            }
            // если переменная от WaveIn не налл, то останавливаем запись
            if (_sourceStream != null)
            {
                _sourceStream.StopRecording();
            }
            // если переменная от WaveFileWriter не налл, то освобождаем ресурс, инициализируем наллом и строим осциллограму
            if (_waveWriter != null)
            {
                StartRecord.Enabled = true;
                _waveWriter.Dispose();
                _waveWriter = null;

                // Очищаем чарт для нового вывода осциллограмы 
                chart2.Series.Clear();
                // Устанавливаем чарт
                chart2.Series.Add("wave");
                chart2.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series["wave"].ChartArea = "ChartArea1";
                chart2.ChartAreas[0].AxisY.Interval = 0.1;

                // Очищаем чарт для нового вывода осциллограмы 
                chart1.Series.Clear();
                // Устанавливаем чарт
                chart1.Series.Add("wave");
                chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart1.Series["wave"].ChartArea = "ChartArea1";
                chart1.ChartAreas[0].AxisY.Interval = 0.1;
                // WaveChannel32 представляет канал для WaveMixerStream, который может микшировать несколько 32 битовых потоков ввода (обычно используется с входных стереоканалов)
                // Присваиваем переменную запоминающую путь сохранения .wav файла  
                WaveChannel32 waveChannel32 = new WaveChannel32(new WaveFileReader(_path));
                //размер буффера
                var buffer = new byte[3916384];
                //индекс левого канала для привязки максимального значения амплитуды к номеру дискрета(времени)
                int indexLeft = 0;
                //индекс левого канала для привязки максимального значения амплитуды к номеру дискрета(времени)
                int indexRight = 0;
                // Перебор текущей позиции что будет длится по всей длине поступаемого потока с waveChannel32
                while (waveChannel32.Position < waveChannel32.Length)
                {
                    //bytesread = waveChannel32.Read(Читает байты из потока; Cмещение в буфере; Количество считанных байтов)
                    var read = waveChannel32.Read(buffer, 0, 3916384);
                    //chart time-magnitude
                    for (var i = 0; i < read/4; i++)
                    {
                        
                        int j = 0; // переменная для правого канала 
                        if (i % 2 == 1) // все четные дискреты будут уходить в левый канал
                            j = i;
                        //chart2.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, j * 4));
                        _volumeRight = (BitConverter.ToSingle(buffer, j*4)); // Вычисления значений амплитуды правого канал
                        int k = 0; // переменная для правого канала 
                        if (i%2 != 1) // все четные дискреты будут уходить в левый канал
                            k = i;
                        //chart1.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, k * 4));
                        _volumeLeft = (BitConverter.ToSingle(buffer, k*4)); // Вычисления значений амплитуды левого канал

                        if (_volumeRight > 0.4f) //Отлавливание амплитуды выше установленного значения правого канала
                        {
                            _ampRight.Add(_volumeRight); //Добавляем в массив левый канал
                            _counterRight.Add(j/(2)); //Добавляем в массив дискреты\время левого канала
                            double maxRight = 0;
                            for (j = 0; j < _ampRight.Count; j++)
                                if (maxRight < (float)_ampRight[j])
                                {
                                    // Запоминаем максимальное значение из всех амлитуд канала
                                    maxRight = (float)_ampRight[j];
                                    // Запоминаем номер дискрета
                                    indexRight = j;
                                }

                            textBox4.Text = maxRight.ToString();
                            //textBox3.Text = indexRight.ToString();
                        }

                        if (_volumeLeft > 0.4f) //Отлавливание амплитуды выше установленного значения правого канала
                        {
                            _ampLeft.Add(_volumeLeft); //Добавляем в массив правый канал
                            _counterLeft.Add(k/(2)); //Добавляем в массив время правого канала


                            double maxLeft = 0;
                            for (k = 0; k < _ampLeft.Count; k++)
                                if (maxLeft < (float)_ampLeft[k])
                                {
                                    // Запоминаем максимальное значение из всех амлитуд канала
                                    maxLeft = (float)_ampLeft[k];
                                    // Запоминаем номер дискрета
                                    indexLeft = k;
                                }

                            textBox2.Text = maxLeft.ToString();
                            //textBox3.Text = indexLeft.ToString();

                            //double max = 0;
                            //int index = 0;
                            //if (max < (double) _ampLeft[k])
                            //{
                            //    // Запоминаем новое максимальное значение
                            //    max = k / 2;
                            //    // Запоминаем порядковый номер
                            //    index = k;
                            //    textBox2.Text = max.ToString();
                            //     textBox3.Text = index.ToString();
                            //}
                            //int index = 0;
                            //double max = 0;
                            //if (_ampLeft[k] > max)
                            //{
                            //    max = _ampLeft[k];
                            //    index = i / 2;

                            //}
                            //textBox2.Text = max.ToString(); textBox3.Text = index.ToString();
                        }
                    }
                }
                
                for (int i = 0; i < _ampRight.Count; i++) // левый канал
                {
                    //начинаем порядковый номер с 1
                    int number = i + 1;
                    //создаем элемент
                    ListViewItem list = new ListViewItem(number.ToString("00"));
                    //добавляем в listview
                    list.SubItems.Add(_ampRight[i].ToString());
                   // double timeLeft = Convert.ToDouble(_counterRight[i].ToString());
                    list.SubItems.Add(_counterRight[i].ToString());
                    listView1.Items.Add(list);
                    textBox5.Text = _counterRight[indexRight].ToString();

                }
                for (int i = 0; i < _ampLeft.Count; i++) //правый канал
                {
                    //начинаем порядковый номер с 1
                    int number = i + 1;
                    //создаем элемент
                    ListViewItem list2 = new ListViewItem(number.ToString("00"));
                    //добавляем в listview
                    list2.SubItems.Add(_ampLeft[i].ToString());
                    //  double timeRight = Convert.ToDouble(_counterLeft[i].ToString());
                    //  list2.SubItems.Add(string.Format("{00:00:000}", timeRight));
                    list2.SubItems.Add(_counterLeft[i].ToString());
                    listView2.Items.Add(list2);
                    textBox3.Text = _counterLeft[indexLeft].ToString();
                }
                int delta = (int)_counterLeft[indexLeft] - (int)_counterRight[indexRight]; // нахождение дельты
                double angle = (340* Math.Abs(delta))/41; 
                textBox6.Text = angle.ToString();
                // для отделения значений разных записей
                ListViewItem list3 = new ListViewItem();
                ListViewItem list4 = new ListViewItem();
                list3.SubItems.Add(" ");
                list3.SubItems.Add(" ");
                list3.SubItems.Add(" ");
                list3.SubItems.Add(" ");
                listView1.Items.Add(list3);
                listView2.Items.Add(list4);
                // Освободжаем waveChannel32
                waveChannel32.Dispose();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int newVolume = ((ushort.MaxValue/10)*trackBar1.Value); // Вычесление громкости, которое будет установлено
            uint newVolumeAllChannels = (((uint) newVolume & 0x0000ffff) | ((uint) newVolume << 16)); // Установить такую же громкость для левого и правого канала
            waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);       // Установите громкость
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            _time = _time.Add(new TimeSpan(0, 0, 1)); // Запускаем таймер с 1 секунды
            label1.Text = _time.Hours.ToString("00") + @":" + _time.Minutes.ToString("00") + @":" + _time.Seconds.ToString("00");
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) 
        {
            // при закрытие формы сохраняем путь к файлу
            Properties.Settings.Default.textBox = textBox1.Text;
            Properties.Settings.Default.Save();
        }
       
        private void ListClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); listView2.Items.Clear(); // очистка листа
            textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
        }

        private void VideoCapture_Click(object sender, EventArgs e)
        {
            Video video = new Video();
            video.ShowDialog(); // показываем новую форму
        }
    }

    //class Discrete
    //{
    //    private float _cout;
    //    private float _chanell;
    //    private float _ms;

    //    public Discrete(float chanell, float ms, float cout)
    //    {
    //        _chanell = chanell;
    //        _ms = ms;
    //        _cout = cout;
    //    }
    //    List<Discrete> discretes = new List<Discrete>();
    //}
}
