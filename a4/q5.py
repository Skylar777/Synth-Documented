import pyaudio
import numpy as np
#import time
import argparse
import threading


rate1 = 44100
buffer1 = 1024
duration = 4.0
attack = 0.1
decay = 0.2
#waveform=0
#t=lineform(0,0,0)
#env=zeros(t)
sustain = 0.5
release = 0.2
car = 440.0
modfreq = 3.0
modind = 10.0
# def adsr_envelope(sample_rate, attack_time, decay_time, sustainlevel, sustain_time, release_time):
#     attack_samples = int(attack_time * sample_rate)
#     decay_samples = np.linspace(0, 1, attack_samples)
#     sustain_samples = np.linspace(1, sustainlevel, decay_samples)
#     release_samples = int(release_time * sample_rate)
#     attack = ?????????

# def callback():
#     #print("hello")
t = np.linspace(0, duration, int(duration * rate1), False)
op1ratioo = 1.0
op1uned = 0.0
op1level = 99
op2ratioo = 2.003
op2uned = 0.0
op2level = 0
op3ratioo = 4.0
op3uned = -7.0
op3level = 99
op4ratioo = 0.0
op4uned = 0.0
op4level = 0
#     

lfofreq = 5.0
lfodepth = 0.1


pitchattack= 0.1
pitchdecay = 0.2
pitchsustain = 0.7
pitchrelease = 0.3
pitchamount = 0.5
#     output1 = op1note + op2note + op3note + op4note
#     #print(output1)
#     output1 = np.asarray(output1, dtype=np.float32).tobytes()
#     #print(output1)
#
    # Scale the waveform to the range [-1, 1]# op1note = op1level * np.sin((2 ** t) + op1uned - np.sin(2 *t))
    # op2note = op2level * np.sin((2 ** t) + op2uned - np.sin(2 *t))
    # op3note = op3level * np.sin((2 ** t) + op3uned - np.sin(2 *t))
    # op4note = op4level * np.sin((2 ** t) + op4uned - np.sin(2 *t))
    #print("hello")
op1note = op1level * np.sin(2 * np.pi * op1ratioo * t + op1uned * np.sin(2 * np.pi * op1ratioo * t))
op2note = op2level * np.sin(2 * np.pi * op2ratioo * t + op2uned * np.sin(2 * np.pi * op2ratioo * t))
p3note = op3level * np.sin(2 * np.pi * op3ratioo * t + op3uned * np.sin(2 * np.pi * op3ratioo * t))
op4note = op4level * np.sin(2 * np.pi * op4ratioo * t + op4uned * np.sin(2 * np.pi * op4ratioo * t))
outputnote = (op1note + op1note + op1note + op1note)

#     decay = ?????
#     sustain = np.ones(sustain_samples) * sustainlevel
#     release = np.linspace(sustainlevel, 0, release_samples)
#     envelope = combine
#     return decay
def q8envelopes(envelope):
    lfowaveform = np.sin(2 * np.pi * np.arange(len(envelope)) * lfofreq / rate1)
    lfowaveform = (lfowaveform + 1) * lfodepth
    #print(lfowaveform)
    newenvelope = envelope * lfowaveform
    pitch = np.linspace(1.0, pitchsustain, len(envelope))
    #print(lfowaveform)
    pitch[:int(pitchdecay * rate1)] = np.linspace(1.0, pitchsustain, int(pitchdecay * rate1))
    wholething = newenvelope * pitch
    #print(lfowaveform)
    return wholething
def adsrenv(duration):
    totalss = int(duration * rate1)
    attackss = int(attack * rate1)
    decayss = int(decay * rate1)
    releasess = int(release * rate1)

    env = np.zeros(totalss)
    env[:attackss] = np.linspace(0, 1, attackss)
    env[attackss:attackss+decayss] = np.linspace(1, sustain, decayss)
    env[-releasess:] = np.linspace(sustain, 0, releasess)
    #print(env)
    #print(attackss)
    #print(decayss)
    #print(releasess)
    #print(sustain)
    return env


def fmsynthesis(note, duration):
    carfreq = car * 2 ** ((note - 69) / 12)
    moddd = carfreq * modfreq
    modamp = carfreq * modind / moddd

    t = np.linspace(0, duration, int(duration * rate1), endpoint=False)
    modulator_waveform = np.sin(2 * np.pi * moddd * t) * modamp
    carrier_waveform = np.sin(2 * np.pi * carfreq * t + modulator_waveform)

    return carrier_waveform


parser = argparse.ArgumentParser(description='Real-time synth with single sinusoidal oscillator and ADSR env')
parser.add_argument('note', type=int, help='MIDI note number (0-127)')
args = parser.parse_args()

# start_time = time.time()

# while (time.time() - start_time) < 4:
#     print(time.time() - start_time)

note = args.note
note2=note+5
note3=note2+5
note4=note3+5
def compute(note):
    waveform = fmsynthesis(note, duration)
    env = adsrenv(duration) * outputnote
    env = q8envelopes(env)
    waveform *= env
    return waveform
waveform=compute(note)
waveform2=compute(note2)
waveform3=compute(note3)
waveform4=compute(note4)

# t = np.linspace(0, duration, int(sample_rate * duration), False)
# freq = 440
# waveform = np.sin(2 * np.pi * freq * t)
audio = pyaudio.PyAudio()
stream = [None] * 4
def playsound(channelnum, waveform):
    stream[channelnum] = audio.open(format=pyaudio.paFloat32, channels=1, rate=rate1, frames_per_buffer=buffer1, output=True)
    # print("open")
    # stream = audio.open(format=8,
    #                 channels=1,
    for i in range(0, len(waveform), buffer1):
        #print("write")
        stream[channelnum].write((waveform[i:i+buffer1].astype(np.float32)).tobytes())
        #stream[channelnum].write((waveform[i:i+buffer1].astype(np.float32)).tobytes()+(b'\x00\x01\x02\x03\x04\x05\x06\x07' * 128))
    # while stream.is_active():
    #         pass
    stream[channelnum].close()

def polyphony():
    # create a thread for each voice
    
    threads = []
    thread = threading.Thread(target=playsound, args=(0, waveform))
    threads.append(thread)
    thread = threading.Thread(target=playsound, args=(1, waveform2))
    threads.append(thread)
    thread = threading.Thread(target=playsound, args=(2, waveform3))
    threads.append(thread)
    thread = threading.Thread(target=playsound, args=(3, waveform4))
    threads.append(thread)
    # thread = threading.Thread(target=playsound, args=(4, waveform4))
    # threads.append(thread)

    #thread.start()
    #thread.join()
    for thread in threads:
        thread.start()

    for thread in threads:
        thread.join()
    #stream.close()
    #stream.terminate()

polyphony()
