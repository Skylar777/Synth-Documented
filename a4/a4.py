from pydub import AudioSegment
from pydub.playback import play
import matplotlib.pyplot as plt
import numpy as np


c4patch1 = AudioSegment.from_file("c4 patch 1.mp3", format="mp3")
c4patch1adsr = AudioSegment.from_file("c4 patch 1 adsr.mp3", format="mp3")
# c4patch2 = AudioSegment.from_file("c4 patch 2.mp3", format="mp3")
# g4patch1 = AudioSegment.from_file("g4 patch 1.mp3", format="mp3")
# g4patch2 = AudioSegment.from_file("g4 patch 2.mp3", format="mp3")
duration = .1
c4patch1arr = np.array(c4patch1.get_array_of_samples())
c4patch1adsrarr = np.array(c4patch1adsr.get_array_of_samples())
# c4patch2arr = np.array(c4patch2.get_array_of_samples())
# g4patch1arr = np.array(g4patch1.get_array_of_samples())
# g4patch2arr = np.array(g4patch2.get_array_of_samples())
start = 40000 
end = start + int(duration * c4patch1.frame_rate)  


plt.plot(c4patch1arr[start:end])
plt.show()
plt.plot(c4patch1adsrarr[start:end])
plt.show()
# plt.plot(c4patch2arr[start:end])
# plt.show()

# plt.plot(g4patch1arr[start:end])
# plt.show()

# plt.plot(g4patch2arr[start:end])
# plt.show()



plt.specgram(c4patch1arr[start:end], Fs=c4patch1.frame_rate)
plt.show()
plt.specgram(c4patch1adsrarr[start:end], Fs=c4patch1adsr.frame_rate)
plt.show()
# plt.specgram(c4patch2arr[start:end], Fs=c4patch2.frame_rate)
# plt.show()

# plt.specgram(g4patch1arr[start:end], Fs=g4patch1.frame_rate)
# plt.show()

# plt.specgram(g4patch2arr[start:end], Fs=g4patch2.frame_rate)
# plt.show()




c4patch1arr_db = 20 * np.log10(np.abs(c4patch1arr))
c4patch1adsrarr_db = 20 * np.log10(np.abs(c4patch1adsrarr))
# c4patch2arr_db = 20 * np.log10(np.abs(c4patch2arr))
# g4patch1arr_db = 20 * np.log10(np.abs(g4patch1arr))
# g4patch2arr_db = 20 * np.log10(np.abs(g4patch2arr))


plt.plot(c4patch1arr_db[start:end])
plt.show()

plt.plot(c4patch1adsrarr_db[start:end])
plt.show()
# plt.plot(c4patch2arr_db[start:end])
# plt.show()

# plt.plot(g4patch1arr_db[start:end])
# plt.show()

# plt.plot(g4patch2arr_db[start:end])
# plt.show()




plt.specgram(c4patch1arr_db[start:end], Fs=c4patch1.frame_rate)
plt.show()
plt.specgram(c4patch1adsrarr_db[start:end], Fs=c4patch1adsr.frame_rate)
plt.show()
# plt.specgram(c4patch2arr_db[start:end], Fs=c4patch2.frame_rate)
# plt.show()

# plt.specgram(g4patch1arr_db[start:end], Fs=g4patch1.frame_rate)
# plt.show()

# plt.specgram(g4patch2arr_db[start:end], Fs=g4patch2.frame_rate)
# plt.show()
