using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using NAudio.Wave;

namespace app{
class Program{
static void twosounds(){
    
    WaveStream stream1= new AudioFileReader("firstsound.wav");
    WaveOutEvent out1 = new();
    out1.Init(stream1);
    stream1.CurrentTime = new TimeSpan(0L);
    out1.Play();

    WaveStream stream2= new AudioFileReader("secondsound.wav");
    WaveOutEvent out2 = new();
    out2.Init(stream2);
    stream2.CurrentTime = new TimeSpan(0L);
    out2.Play();

    Console.ReadKey();
}

static void howmany(){
    
    WaveStream stream1= new AudioFileReader("howmany.wav");
    WaveOutEvent out1 = new();
    out1.Init(stream1);
    stream1.CurrentTime = new TimeSpan(0L);
    out1.Play();

    WaveStream stream2= new AudioFileReader("howmany.wav");
    WaveOutEvent out2 = new();
    out2.Init(stream2);
    stream2.CurrentTime = new TimeSpan(0L);
    out2.Play();

    WaveStream stream3= new AudioFileReader("howmany.wav");
    WaveOutEvent out3 = new();
    out3.Init(stream3);
    stream3.CurrentTime = new TimeSpan(0L);
    out3.Play();

    WaveStream stream4= new AudioFileReader("howmany.wav");
    WaveOutEvent out4 = new();
    out4.Init(stream4);
    stream4.CurrentTime = new TimeSpan(0L);
    out4.Play();

    // WaveStream stream5= new AudioFileReader("howmany.wav");
    // WaveOutEvent out5 = new();
    // out5.Init(stream5);
    // stream5.CurrentTime = new TimeSpan(0L);
    // out5.Play();

    // WaveStream stream6= new AudioFileReader("howmany.wav");
    // WaveOutEvent out6 = new();
    // out6.Init(stream6);
    // stream6.CurrentTime = new TimeSpan(0L);
    // out6.Play();

    Console.ReadKey();
}
static double sawtooth(double x)
{
    return (x - Math.PI)/Math.PI;
}
static double pulse(double x)
{
    return Math.Sign(sawtooth(x));
}
static double triangle(double x)
{
    return 1 - 2 * Math.Abs(sawtooth(x));
}
static double noise(double x)
{
    Random rnd = new Random();
    double num = rnd.NextDouble();
    return num;
}
static void JingleBells1(string samplesnum)
{
    string[] info={"69",".3"};
    sample(info, samplesnum);
    info=new string[] {"69", ".3"};
    sample(info, samplesnum);
    info=new string[] {"69",".6"};
    sample(info, samplesnum);
    info=new string[] {"74",".3"};
    sample(info, samplesnum);
    info=new string[] {"74",".3"};
    sample(info, samplesnum);
    info=new string[] {"74",".6"};
    sample(info, samplesnum);
    info=new string[] {"69",".3"};
    sample(info, samplesnum);
    info=new string[] {"71",".3"};
    sample(info, samplesnum);
    info=new string[] {"74",".6"};
    sample(info, samplesnum);
    info=new string[] {"69",".15"};
    sample(info, samplesnum);
    info=new string[] {"71",".15"};
    sample(info, samplesnum);
    Thread.Sleep(500);
    info=new string[] {"71",".3"};
    sample(info, samplesnum);
    info=new string[] {"71",".3"};
    sample(info, samplesnum);
    info=new string[] {"71",".3"};
    sample(info, samplesnum);
    info=new string[] {"70",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"70",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"70",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"69",".3"};
    sample(info, samplesnum);
    Thread.Sleep(400);
    info=new string[] {"70",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"72",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"72",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"73",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"71",".15"};
    sample(info, samplesnum);
    Thread.Sleep(100);
    info=new string[] {"69",".3"};
    sample(info, samplesnum);
}
static void score1(string[] args2, string samplesnum)
{  
    string[] info1={"69",".3"};
    for (int i=1; i<args2.Length ; i+=2){
        if(args2[i]=="rest"){
            Thread.Sleep(Int32.Parse(args2[i+1]));
            Console.WriteLine("sleeping");
        }else{
            info1=new string[] {args2[i], args2[i+1]};
            sample(info1, samplesnum);
        }
    }
}
static void sample(string[] args1, string samplesnum)
{
    double samplesnum1=Convert.ToDouble(samplesnum);
    UInt16 frequency=440;
    double sDuration=1;
    double trueDuration=3;
    UInt16 volume = 50000;
    double TAU = 2 * Math.PI;
    int pulse1=0;
    int sawtooth1=0;
    int triangle1=0;
    int noise1=0;
    int samplesPerSecond = (int)samplesnum1;
    if (args1.Length!=0){
        if(args1[0]=="pulse"){
            pulse1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="sawtooth"){
            sawtooth1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="triangle"){
            triangle1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="noise"){
            noise1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="score"){
            Console.WriteLine("Playing Score");
            score1(args1, samplesnum);
            return;
        }
        if(args1[0]=="JingleBells"){
            Console.WriteLine("Playing JingleBells");
            JingleBells1(samplesnum);
            return;
        }
        Console.WriteLine("MIDI note # is "+args1[0]);
        Console.WriteLine("Duration in seconds is "+args1[1]);
        sDuration=Convert.ToDouble(args1[1]);
        double power=Convert.ToDouble(args1[0]);
        TAU = Math.Pow(2,  ((power-69)/12));
    }
    File.Delete("test.wav");
    FileStream f = new FileStream("test.wav", FileMode.Create);
    BinaryWriter writer = new BinaryWriter(f);
    int formatChunkSize = 16;
    int headerSize = 8;
    short formatType = 1;
    short tracks = 1;
    short bitsPerSample = 16;
    short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
    int bytesPerSecond = samplesPerSecond * frameSize;
    int waveSize = 4;
    int samples = (int)(samplesPerSecond * sDuration);
    int dataChunkSize = samples * frameSize;
    int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
    writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
    writer.Write(fileSize);
    writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
    writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
    writer.Write(formatChunkSize);
    writer.Write(formatType);
    writer.Write(tracks);
    writer.Write(samplesPerSecond);
    writer.Write(bytesPerSecond);
    writer.Write(frameSize);
    writer.Write(bitsPerSample);
    writer.Write(0x61746164); // = encoding.GetBytes("data")
    writer.Write(dataChunkSize);
    {
        double theta = frequency * TAU / (double)samplesPerSecond;
        if(args1.Length!=0)
            theta*= 6.28318530718;
        Console.WriteLine(theta);
        double amp = volume >> 2; 
        for (int step = 0; step < samples; step++)
        {   short s;
            if(noise1==1){
                s = (short)(amp * noise(theta * (double)step));
            }else if(pulse1==1){
                s = (short)(amp * pulse(theta * (double)step));
            }else if(triangle1==1){
                s = (short)(amp * triangle(theta * (double)step));
            }else if(sawtooth1==1){
                s = (short)(amp * sawtooth(theta * (double)step));
            }else{
                s = (short)(amp * Math.Sin(theta * (double)step));
            }
            
            
            writer.Write(s);
        }
    }

    writer.Close();
    writer.Dispose();
    using (SoundPlayer player = new SoundPlayer("test.wav"))
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        //Console.WriteLine("playing at " + (timer.ElapsedMilliseconds/1000)  + " seconds");
        //player.LoadAsync();
        player.PlayLooping();
        Thread.Sleep((int)(trueDuration*1000));
        Console.WriteLine("played for " + (timer.ElapsedMilliseconds/1000)  + " seconds");
        timer.Stop();
    }
}
static void score(string[] args2)
{  
    string[] info1={"69",".3"};
    for (int i=1; i<args2.Length ; i+=2){
        if(args2[i]=="rest"){
            Thread.Sleep(Int32.Parse(args2[i+1]));
            Console.WriteLine("sleeping");
        }else{
            info1=new string[] {args2[i], args2[i+1]};
            sinewave(info1);
        }
    }
}
static void JingleBells()
{
    string[] info={"69",".3"};
    sinewave(info);
    info=new string[] {"69", ".3"};
    sinewave(info);
    info=new string[] {"69",".6"};
    sinewave(info);
    info=new string[] {"74",".3"};
    sinewave(info);
    info=new string[] {"74",".3"};
    sinewave(info);
    info=new string[] {"74",".6"};
    sinewave(info);
    info=new string[] {"69",".3"};
    sinewave(info);
    info=new string[] {"71",".3"};
    sinewave(info);
    info=new string[] {"74",".6"};
    sinewave(info);
    info=new string[] {"69",".15"};
    sinewave(info);
    info=new string[] {"71",".15"};
    sinewave(info);
    Thread.Sleep(500);
    info=new string[] {"71",".3"};
    sinewave(info);
    info=new string[] {"71",".3"};
    sinewave(info);
    info=new string[] {"71",".3"};
    sinewave(info);
    info=new string[] {"70",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"70",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"70",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"69",".3"};
    sinewave(info);
    Thread.Sleep(400);
    info=new string[] {"70",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"72",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"72",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"73",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"71",".15"};
    sinewave(info);
    Thread.Sleep(100);
    info=new string[] {"69",".3"};
    sinewave(info);
}
static void secondsound(string[] args1)
{
    UInt16 frequency=440;
    double sDuration=3;
    UInt16 volume = 50000;
    double TAU = 2 * Math.PI;
    int pulse1=0;
    int sawtooth1=0;
    int triangle1=0;
    int noise1=0;
    if (args1.Length!=0){
        if(args1[0]=="pulse"){
            pulse1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="sawtooth"){
            sawtooth1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="triangle"){
            triangle1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="noise"){
            noise1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="score"){
            Console.WriteLine("Playing Score");
            score(args1);
            return;
        }
        if(args1[0]=="JingleBells"){
            Console.WriteLine("Playing JingleBells");
            JingleBells();
            return;
        }
        Console.WriteLine("MIDI note # is "+args1[0]);
        Console.WriteLine("Duration in seconds is "+args1[1]);
        sDuration=Convert.ToDouble(args1[1]);
        double power=Convert.ToDouble(args1[0]);
        TAU = Math.Pow(2,  ((power-69)/12));
    }
    File.Delete("secondsound.wav");
    FileStream f = new FileStream("secondsound.wav", FileMode.Create);
    BinaryWriter writer = new BinaryWriter(f);
    int formatChunkSize = 16;
    int headerSize = 8;
    short formatType = 1;
    short tracks = 1;
    int samplesPerSecond = 44100;
    short bitsPerSample = 16;
    short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
    int bytesPerSecond = samplesPerSecond * frameSize;
    int waveSize = 4;
    int samples = (int)(samplesPerSecond * sDuration);
    int dataChunkSize = samples * frameSize;
    int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
    writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
    writer.Write(fileSize);
    writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
    writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
    writer.Write(formatChunkSize);
    writer.Write(formatType);
    writer.Write(tracks);
    writer.Write(samplesPerSecond);
    writer.Write(bytesPerSecond);
    writer.Write(frameSize);
    writer.Write(bitsPerSample);
    writer.Write(0x61746164); // = encoding.GetBytes("data")
    writer.Write(dataChunkSize);
    {
        double theta = frequency * TAU / (double)samplesPerSecond;
        if(args1.Length!=0)
            theta*= 6.28318530718;
        Console.WriteLine(theta);
        double amp = volume >> 2; 
        for (int step = 0; step < samples; step++)
        {   short s;
            if(noise1==1){
                s = (short)(amp * noise(theta * (double)step));
            }else if(pulse1==1){
                s = (short)(amp * pulse(theta * (double)step));
            }else if(triangle1==1){
                s = (short)(amp * triangle(theta * (double)step));
            }else if(sawtooth1==1){
                s = (short)(amp * sawtooth(theta * (double)step));
            }else{
                s = (short)(amp * Math.Sin(theta * (double)step));
            }
            
            
            writer.Write(s);
        }
    }

    
    writer.Close();
    writer.Dispose();
}
static void firstsound(string[] args1)
{
    UInt16 frequency=440;
    double sDuration=3;
    UInt16 volume = 50000;
    double TAU = 2 * Math.PI;
    int pulse1=0;
    int sawtooth1=0;
    int triangle1=0;
    int noise1=0;
    if (args1.Length!=0){
        if(args1[0]=="pulse"){
            pulse1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="sawtooth"){
            sawtooth1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="triangle"){
            triangle1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="noise"){
            noise1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="score"){
            Console.WriteLine("Playing Score");
            score(args1);
            return;
        }
        if(args1[0]=="JingleBells"){
            Console.WriteLine("Playing JingleBells");
            JingleBells();
            return;
        }
        Console.WriteLine("MIDI note # is "+args1[0]);
        Console.WriteLine("Duration in seconds is "+args1[1]);
        sDuration=Convert.ToDouble(args1[1]);
        double power=Convert.ToDouble(args1[0]);
        TAU = Math.Pow(2,  ((power-69)/12));
    }
    File.Delete("firstsound.wav");
    FileStream f = new FileStream("firstsound.wav", FileMode.Create);
    BinaryWriter writer = new BinaryWriter(f);
    int formatChunkSize = 16;
    int headerSize = 8;
    short formatType = 1;
    short tracks = 1;
    int samplesPerSecond = 44100;
    short bitsPerSample = 16;
    short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
    int bytesPerSecond = samplesPerSecond * frameSize;
    int waveSize = 4;
    int samples = (int)(samplesPerSecond * sDuration);
    int dataChunkSize = samples * frameSize;
    int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
    writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
    writer.Write(fileSize);
    writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
    writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
    writer.Write(formatChunkSize);
    writer.Write(formatType);
    writer.Write(tracks);
    writer.Write(samplesPerSecond);
    writer.Write(bytesPerSecond);
    writer.Write(frameSize);
    writer.Write(bitsPerSample);
    writer.Write(0x61746164); // = encoding.GetBytes("data")
    writer.Write(dataChunkSize);
    {
        double theta = frequency * TAU / (double)samplesPerSecond;
        if(args1.Length!=0)
            theta*= 6.28318530718;
        Console.WriteLine(theta);
        double amp = volume >> 2; 
        for (int step = 0; step < samples; step++)
        {   short s;
            if(noise1==1){
                s = (short)(amp * noise(theta * (double)step));
            }else if(pulse1==1){
                s = (short)(amp * pulse(theta * (double)step));
            }else if(triangle1==1){
                s = (short)(amp * triangle(theta * (double)step));
            }else if(sawtooth1==1){
                s = (short)(amp * sawtooth(theta * (double)step));
            }else{
                s = (short)(amp * Math.Sin(theta * (double)step));
            }
            
            
            writer.Write(s);
        }
    }

    
    writer.Close();
    writer.Dispose();
}
static void sinewave(string[] args1)
{
    UInt16 frequency=440;
    double sDuration=3;
    UInt16 volume = 50000;
    double TAU = 2 * Math.PI;
    int pulse1=0;
    int sawtooth1=0;
    int triangle1=0;
    int noise1=0;
    if (args1.Length!=0){
        if(args1[0]=="pulse"){
            pulse1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="sawtooth"){
            sawtooth1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="triangle"){
            triangle1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="noise"){
            noise1=1;
            args1 = args1.Skip(1).ToArray();
        }
        if(args1[0]=="score"){
            Console.WriteLine("Playing Score");
            score(args1);
            return;
        }
        if(args1[0]=="JingleBells"){
            Console.WriteLine("Playing JingleBells");
            JingleBells();
            return;
        }
        Console.WriteLine("MIDI note # is "+args1[0]);
        Console.WriteLine("Duration in seconds is "+args1[1]);
        sDuration=Convert.ToDouble(args1[1]);
        double power=Convert.ToDouble(args1[0]);
        TAU = Math.Pow(2,  ((power-69)/12));
    }
    File.Delete("test.wav");
    FileStream f = new FileStream("test.wav", FileMode.Create);
    BinaryWriter writer = new BinaryWriter(f);
    int formatChunkSize = 16;
    int headerSize = 8;
    short formatType = 1;
    short tracks = 1;
    int samplesPerSecond = 44100;
    short bitsPerSample = 16;
    short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
    int bytesPerSecond = samplesPerSecond * frameSize;
    int waveSize = 4;
    int samples = (int)(samplesPerSecond * sDuration);
    int dataChunkSize = samples * frameSize;
    int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
    writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
    writer.Write(fileSize);
    writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
    writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
    writer.Write(formatChunkSize);
    writer.Write(formatType);
    writer.Write(tracks);
    writer.Write(samplesPerSecond);
    writer.Write(bytesPerSecond);
    writer.Write(frameSize);
    writer.Write(bitsPerSample);
    writer.Write(0x61746164); // = encoding.GetBytes("data")
    writer.Write(dataChunkSize);
    {
        double theta = frequency * TAU / (double)samplesPerSecond;
        if(args1.Length!=0)
            theta*= 6.28318530718;
        Console.WriteLine(theta);
        double amp = volume >> 2; 
        for (int step = 0; step < samples; step++)
        {   short s;
            if(noise1==1){
                s = (short)(amp * noise(theta * (double)step));
            }else if(pulse1==1){
                s = (short)(amp * pulse(theta * (double)step));
            }else if(triangle1==1){
                s = (short)(amp * triangle(theta * (double)step));
            }else if(sawtooth1==1){
                s = (short)(amp * sawtooth(theta * (double)step));
            }else{
                s = (short)(amp * Math.Sin(theta * (double)step));
            }
            
            
            writer.Write(s);
        }
    }

    
    writer.Close();
    writer.Dispose();
    using (SoundPlayer player = new SoundPlayer("test.wav"))
    {
        player.PlaySync();
    }
}
static void Main(string[] args)
{
    if (args.Length!=0){
        if(args[0]=="sample"){
            Console.WriteLine("Playing "+args[1]+" samples.");
            //Console.WriteLine(args[0]);
            args = args.Skip(1).ToArray();  
            string samplesnum = args[0];
            args = args.Skip(1).ToArray(); 
            sample(args, samplesnum);
            return;
        }
        if(args[0]=="howmany"){
            howmany();
            return;
        }
        if(args[0]=="poly"){
            string[] first={args[1], args[2]};
            string[] second={args[3], args[4]};
            firstsound(first);
            secondsound(second);
            twosounds();
            return;
        }
    }
        
    sinewave(args);
    
} 
}
}