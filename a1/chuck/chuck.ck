


// print each
int midi;
69=>midi;
float sec;
3=>sec;
if(me.args()>0)
{
    <<< "number of arguments:", me.args() >>>;
    if(me.arg(0)=="sawtooth"){
        SawOsc s => dac;
        Std.mtof(midi)=> s.freq;
        0.5=>s.gain;
        // allow 3 seconds to pass
        //automatically at 44100Hz
        sec::second => now;
    }
    else if(me.arg(0)=="triangle"){
        TriOsc s => dac;
        Std.mtof(midi)=> s.freq;
        0.5=>s.gain;
        // allow 3 seconds to pass
        //automatically at 44100Hz
        sec::second => now;
    }
    else if(me.arg(0)=="pulse"){
        PulseOsc s => dac;
        Std.mtof(midi)=> s.freq;
        0.5=>s.gain;
        // allow 3 seconds to pass
        //automatically at 44100Hz
        sec::second => now;
    }
    else if(me.arg(0)=="noise"){
        Noise s => dac;
        Std.mtof(midi)=> s.freq;
        0.5=>s.gain;
        // allow 3 seconds to pass
        //automatically at 44100Hz
        sec::second => now;
    }
    else if(me.arg(0)=="jinglebells"){
        SinOsc s => dac;
        0.5=>s.gain;
        Std.mtof(69)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(69)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(69)=> s.freq;
        .6::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(74)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(74)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(74)=> s.freq;
        .6::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(69)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(71)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(74)=> s.freq;
        .6::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(69)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(71)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(71)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(71)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(71)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(70)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        Std.mtof(70)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(70)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(69)=> s.freq;
        .3::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(70)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(72)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(72)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(73)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(71)=> s.freq;
        .15::second => now;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        0.0=>s.gain;
        .1::second => now;
        0.5=>s.gain;
        //sleep
        Std.mtof(69)=> s.freq;
        .3::second => now;
    }else{
        SinOsc s => dac;
        for( int i; i < me.args(); i++ )
        {
            
            if(me.arg(i)=="rest"){
                Std.atof(me.arg(i+1))=>sec;
                Std.mtof(0)=> s.freq;
                <<<"midi: rest  sec:",sec>>>;
                0.0=>s.gain;
            }else{
                Std.atoi(me.arg(i))=>midi;
                Std.atof(me.arg(i+1))=>sec;
                <<<"midi:",midi," sec:",sec>>>;
                Std.mtof(midi)=> s.freq;
                0.5=>s.gain;
            }
            // allow 3 seconds to pass
            //automatically at 44100Hz
            sec::second => now;
            i++;
        }
    }
}else{
    // connect sine oscillator to D/A convertor (sound card)
    SinOsc s => dac;
    Std.mtof(midi)=> s.freq;
    0.5=>s.gain;
    // allow 3 seconds to pass
    //automatically at 44100Hz
    sec::second => now;

}