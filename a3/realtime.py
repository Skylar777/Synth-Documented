import pyaudio
import numpy as np


srate = 44100  # Sample rate
duration = 5.0  # Duration in seconds
freqs = [440, 880, 1320, 1760]  # Frequencies of the partials
amps = [1.0, 0.5, 0.3, 0.2]  # Amplitudes of the partials

# Compute the waveform
t = np.linspace(0, duration, int(srate * duration), False)

waveform = np.zeros_like(t)
for f, a in zip(freqs, amps):
    waveform += a * np.sin(2 * np.pi * f * t)

# Scale the waveform to [-1, 1]
waveform /= np.max(np.abs(waveform))

# Initialize PyAudio
p = pyaudio.PyAudio()
stream = p.open(format=pyaudio.paFloat32, channels=1, rate=srate, output=True)

# Stream the waveform in real time
chunk_size = 1024
n_chunks = int(np.ceil(duration * srate / chunk_size))
for i in range(n_chunks):
    chunk = waveform[i * chunk_size:(i + 1) * chunk_size]
    stream.write(chunk.astype(np.float32).tobytes())

# Clean up
stream.stop_stream()
stream.close()
p.terminate()