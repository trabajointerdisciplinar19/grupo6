import sys
import sqlite3
import os
con = sqlite3.connect('Assets\Plugins\juego.db')
import random
import matplotlib
# Make sure that we are using QT5
matplotlib.use('Qt5Agg')
from PyQt5 import QtCore, QtWidgets
from PyQt5.QtWidgets import QApplication, QMainWindow, QMenu, QVBoxLayout,QHBoxLayout, QSizePolicy, QMessageBox, QWidget
import numpy as np
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure
from matplotlib.animation import FuncAnimation

from random import choice
from PyQt5.QtWidgets import *
from PyQt5 import QtCore
from PyQt5.QtWidgets import QApplication, QMainWindow, QMenu, QVBoxLayout, QSizePolicy, QMessageBox, QWidget



class MyMplCanvas(FigureCanvas):
    def __init__(self, parent=None, width=5, height=4, dpi=100):
        fig = Figure(figsize=(width, height), dpi=dpi)
        self.ax = fig.add_subplot(111)
        self.compute_initial_figure()
        FigureCanvas.__init__(self, fig)
        self.setParent(parent)
        FigureCanvas.setSizePolicy(self,
                                   QtWidgets.QSizePolicy.Expanding,
                                   QtWidgets.QSizePolicy.Expanding)
        FigureCanvas.updateGeometry(self)

    def compute_initial_figure(self):
        pass

class ApplicationWindow(QtWidgets.QMainWindow):
    def __init__(self):
        QtWidgets.QMainWindow.__init__(self)
        self.resize(940,650)
        self.setWindowTitle("Procesos")
        self.main_widget = QtWidgets.QWidget(self)
        cursorObj = con.cursor()
        cursorObj.execute('SELECT usuario.nickname FROM usuario')
        self.alumnos=cursorObj.fetchall()
        self.alumnos=[i[0] for i in self.alumnos]
        self.cont=0
        self.graf={}
        for i in self.alumnos:
            self.graf[i]=[]
        cursorObj = con.cursor()
        cursorObj.execute('SELECT registro.nickalumno,registro.fecha,registro.notaal FROM registro')
        rows = cursorObj.fetchall()
        print(rows)
        for i in rows:
            self.graf[i[0]].append(i[2])
        self.canvas =  MyMplCanvas( self.main_widget,width=5, height=4, dpi=100) ###attention###
        vertical_layout = QVBoxLayout(self.main_widget)
        vertical_layout.addWidget(self.canvas)
        self.Mpl= QtWidgets.QWidget(self.main_widget)
        self.Mpl.setLayout(vertical_layout)
        self.Mpl.setGeometry(QtCore.QRect(20, 130, 850, 500))
#Creacion de Botones
        #Botones de Control
        self.FCFS = QtWidgets.QPushButton("Back",self.main_widget)
        self.FCFS.setGeometry(QtCore.QRect(20, 30, 250, 80))
        self.FCFS.setStyleSheet("font: 16pt \"MS Shell Dlg 2\";")
        self.FCFS.setObjectName("Back")
        self.nom = QtWidgets.QPushButton("Usuario",self.main_widget)
        self.nom.setGeometry(QtCore.QRect(620, 30, 250, 80))
        self.nom.setStyleSheet("font: 10pt \"MS Shell Dlg 2\";")
        self.nom.setObjectName("Usuario")
        self.next = QtWidgets.QPushButton("Next",self.main_widget)
        self.next.setGeometry(QtCore.QRect(320, 30, 250, 80))
        self.next.setStyleSheet("font: 16pt \"MS Shell Dlg 2\";")
        self.next.setObjectName("Next")
        #Boton de paro y salida
        self.stop_button = QtWidgets.QPushButton("stop",self.main_widget)
        self.stop_button.setGeometry(QtCore.QRect(870, 250, 50, 23))
        self.stop_button.setObjectName("stop_button")
        self.exit_button = QtWidgets.QPushButton("exit",self.main_widget)
        self.exit_button.setGeometry(QtCore.QRect(870, 290, 50, 23))
        self.exit_button.setObjectName("exit_button")
#Inicializar Botones
        self.FCFS.clicked.connect(self.pro)
        self.next.clicked.connect(self.pro2)
        self.stop_button.clicked.connect(self.on_stop)
        self.exit_button.clicked.connect(self.on_exit)
        self.setCentralWidget(self.main_widget)



    def update_line(self, i):
        return self.canvas.ax.plot([i,i*2],[i*2,i/2])


    def pro(self):
        if self.cont==0:
            self.cont=len(self.alumnos)-1
        else:
            self.cont-=1
        a=self.alumnos[self.cont]
        self.nom.setText(a)
        self.canvas.ax.clear()
        self.canvas.ax.plot([i for i in range(len(self.graf[a])+1)],[0]+[i for i in self.graf[a]],'o')
        self.canvas.ax.plot([i for i in range(len(self.graf[a])+1)],[0]+[i for i in self.graf[a]])
        self.canvas.draw()
        #print(12)
    def pro2(self):
        if self.cont==len(self.alumnos)-1:
            self.cont=0
        else:
            self.cont+=1
        a=self.alumnos[self.cont]
        self.nom.setText(a)
        self.canvas.ax.clear()
        self.canvas.ax.plot([i for i in range(len(self.graf[a])+1)],[0]+[i for i in self.graf[a]],'o')
        self.canvas.ax.plot([i for i in range(len(self.graf[a])+1)],[0]+[i for i in self.graf[a]])
        self.canvas.draw()
          
    def on_start(self):
        self.ani = FuncAnimation(self.canvas.figure, self.update_line,\
                                 frames=[i for i in 100],
                                 blit=True, interval=100, repeat=False)
    def on_stop(self):
        self.ani._stop()

    def on_exit(self):
        self.close()

if __name__ == "__main__":
    App = QApplication(sys.argv)
    aw = ApplicationWindow()
    aw.show()
    App.exit()
    sys.exit(App.exec_())


