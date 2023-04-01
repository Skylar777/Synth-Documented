from PyQt5.QtCore import Qt, QThread
from PyQt5.QtWidgets import QApplication, QMainWindow, QWidget, QVBoxLayout, QHBoxLayout, QLabel, QSlider, QPushButton, QComboBox
#import threading
#import tkinter as tk

class SynthesizerGUI(QMainWindow):
    def __init__(self):
        super().__init__()
        #window = tk.Tk()
        # Create main widget and layout
        self.main_widget = QWidget(self)
        self.main_layout = QVBoxLayout()
        self.main_widget.setLayout(self.main_layout)
        #greeting = tk.Label(text="Hello, Tkinter")
        # Create oscillator widgets and layouts
        self.osc_labels = []
        #greeting.pack()
        self.freq_sliders = []
        self.waveform_combos = []
        self.freq_labels = []
        #window.mainloop()
        for i in range(4):
            # Create oscillator label
            label = QLabel(f"Oscillator {i+1}")
            self.osc_labels.append(label)
            #label = tk.Label(text="Hello, Tkinter")
            # Create frequency slider
            freq_slider = QSlider(Qt.Horizontal)
            freq_slider.setMinimum(20)
            freq_slider.setMaximum(3000)
            freq_slider.setValue(440)
            freq_slider.setSingleStep(1)
            freq_slider.valueChanged.connect(lambda value, index=i: self.set_freq_label(value, index))
            self.freq_sliders.append(freq_slider)
#             label = tk.Label(
#     text="Hello, Tkinter",
#     foreground="white",  # Set the text color to white
#     background="black"  # Set the background color to black
# )
            # Create waveform combo box
            waveform_combo = QComboBox()
            waveform_combo.addItem("sine")
            waveform_combo.addItem("square")
            waveform_combo.addItem("sawtooth")
            waveform_combo.addItem("triangle")
            self.waveform_combos.append(waveform_combo)
            #vlabel = tk.Label(text="Hello, Tkinter", background="#34A2FE")
            # Create frequency label
            freq_label = QLabel("440 Hz")
            self.freq_labels.append(freq_label)
            #label = tk.Label(text="Hello, Tkinter", fg="white", bg="black")
            # Create oscillator layout
            oscillator_layout = QHBoxLayout()
            oscillator_layout.addWidget(label)
            oscillator_layout.addWidget(freq_slider)
            oscillator_layout.addWidget(waveform_combo)
            oscillator_layout.addWidget(freq_label)
            self.main_layout.addLayout(oscillator_layout)
#             label = tk.Label(
#     text="Hello, Tkinter",
#     fg="white",
#     bg="black",
#     width=10,
#     height=10
# )
        # Create ADSR envelope widgets and layout
        self.attack_slider = QSlider(Qt.Horizontal)
        self.attack_slider.setMinimum(0)
        self.attack_slider.setMaximum(1000)
        self.attack_slider.setValue(10)
        self.attack_slider.setSingleStep(1)
        self.attack_slider.valueChanged.connect(lambda value: self.set_adsr_label("attack", value))
        self.attack_label = QLabel("0.010 s")
        attack_layout = QHBoxLayout()
        attack_layout.addWidget(QLabel("Attack:"))
        attack_layout.addWidget(self.attack_slider)
        attack_layout.addWidget(self.attack_label)
#         button = tk.Button(
#     text="Click me!",
#     width=25,
#     height=5,
#     bg="blue",
#     fg="yellow",
# )
        self.decay_slider = QSlider(Qt.Horizontal)
        self.decay_slider.setMinimum(0)
        self.decay_slider.setMaximum(1000)
        self.decay_slider.setValue(100)
        self.decay_slider.setSingleStep(1)
        self.decay_slider.valueChanged.connect(lambda value: self.set_adsr_label("decay", value))
        self.decay_label = QLabel("0.100 s")
        decay_layout = QHBoxLayout()
        decay_layout.addWidget(QLabel("Decay:"))
        decay_layout.addWidget(self.decay_slider)
        decay_layout.addWidget(self.decay_label)
        
        self.sustain_slider = QSlider(Qt.Horizontal)
        self.sustain_slider.setMinimum(0)
        self.sustain_slider.setMaximum(100)
        self.sustain_slider.setValue(50)
        self.sustain_slider.setSingleStep(1)
        self.sustain_slider.valueChanged.connect(lambda value: self.set_adsr_label("sustain", value))
        self.sustain_label = QLabel("0.500")
        sustain_layout = QHBoxLayout()
        sustain_layout.addWidget(QLabel("Sustain:"))
        sustain_layout.addWidget(self.sustain_slider)
        sustain_layout.addWidget(self.sustain_label)

        self.release_slider = QSlider(Qt.Horizontal)
        self.release_slider.setMinimum(0)
        self.release_slider.setMaximum(1000)
        self.release_slider.setValue(100)
        self.release_slider.setSingleStep(1)
        self.release_slider.valueChanged.connect(lambda value: self.set_adsr_label("decay", value))
        self.release_label = QLabel("0.100 s")
        release_layout = QHBoxLayout()
        release_layout.addWidget(QLabel("release:"))
        release_layout.addWidget(self.release_slider)
        release_layout.addWidget(self.release_label)
        
        adsr_layout = QVBoxLayout()
        adsr_layout.addLayout(attack_layout)
        adsr_layout.addLayout(decay_layout)
        adsr_layout.addLayout(sustain_layout)
        adsr_layout.addLayout(release_layout)
        self.main_layout.addLayout(adsr_layout)
        #entry = tk.Entry(fg="yellow", bg="blue", width=50)
        # Create sample rate widget and layout
        self.sample_rate_slider = QSlider(Qt.Horizontal)
        self.sample_rate_slider.setMinimum(8000)
        self.sample_rate_slider.setMaximum(44100)
        self.sample_rate_slider.setValue(22050)
        self.sample_rate_slider.setSingleStep(1000)
        self.sample_rate_slider.valueChanged.connect(self.set_sample_rate_label)
        self.sample_rate_label = QLabel("Sample Rate: 22050 Hz")
        sample_rate_layout = QHBoxLayout()
        sample_rate_layout.addWidget(self.sample_rate_slider)
        sample_rate_layout.addWidget(self.sample_rate_label)
        self.main_layout.addLayout(sample_rate_layout)
        #window=Tk()
# # add widgets here

# window.title('Hello Python')
# window.geometry("300x200+10+20")
# window.mainloop()
        # Create play and stop buttons
        self.play_button = QPushButton("Play")
        self.play_button.clicked.connect(self.play_sound)
        self.stop_button = QPushButton("Stop")
        self.stop_button.clicked.connect(self.stop_sound)
        button_layout = QHBoxLayout()
        button_layout.addWidget(self.play_button)
        button_layout.addWidget(self.stop_button)
        self.main_layout.addLayout(button_layout)
#         window=Tk()
# btn=Button(window, text="This is Button widget", fg='blue')
# btn.place(x=80, y=100)
# window.title('Hello Python')
# window.geometry("300x200+10+10")
# window.mainloop()
        # Set main widget
        self.setCentralWidget(self.main_widget)
        self.setGeometry(100, 100, 500, 300)
        self.setWindowTitle("Synthesizer GUI")
        self.show()
        
    def set_freq_label(self, value, index):
        frequency = round(value, -1)
        self.freq_labels[index].setText(f"{frequency} Hz")
        #window=Tk()
# btn=Button(window, text="This is Button widget", fg='blue')
# btn.place(x=80, y=100)
# lbl=Label(window, text="This is Label widget", fg='red', font=("Helvetica", 16))
# lbl.place(x=60, y=50)
# txtfld=Entry(window, text="This is Entry Widget", bd=5)
# txtfld.place(x=80, y=150)
# window.title('Hello Python')
# window.geometry("300x200+10+10")
# window.mainloop()
    def set_adsr_label(self, param, value):
        if param == "attack":
            time = round(value / 1000, 3)
            self.attack_label.setText(f"{time:.3f} s")
        elif param == "decay":
            time = round(value / 1000, 3)
            self.decay_label.setText(f"{time:.3f} s")
        elif param == "sustain":
            level = round(value / 100, 3)
            self.sustain_label.setText(f"{level:.3f}")
            
    def set_sample_rate_label(self, value):
        self.sample_rate_label.setText(f"Sample Rate: {value} Hz")
            
    def play_sound(self):
        # v0=IntVar()
# v0.set(1)
# r1=Radiobutton(window, text="male", variable=v0,value=1)
# r2=Radiobutton(window, text="female", variable=v0,value=2)
# r1.place(x=100,y=50)
# r2.place(x=180, y=50)
        pass
    
    def stop_sound(self):
        # v1 = IntVar()
# v2 = IntVar()
# C1 = Checkbutton(window, text = "Cricket", variable = v1)
# C2 = Checkbutton(window, text = "Tennis", variable = v2)
# C1.place(x=100, y=100)
# C2.place(x=180, y=100)
        pass

if __name__ == '__main__':
    app = QApplication([])
    gui1 = SynthesizerGUI()
    gui1.show()

    gui2 = SynthesizerGUI()
    gui2.show()
    app.exec_()
    

