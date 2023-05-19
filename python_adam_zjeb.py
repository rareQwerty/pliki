import tkinter
from tkinter import messagebox

okno = tkinter.Tk()

wypelnienie = tkinter.Canvas(okno, width = 400, height = 300)
wypelnienie.pack()

etykieta_1 = tkinter.Label(okno, text = "Podaj pierwsza liczbe")
wypelnienie.create_window(200, 80, window = etykieta_1)

pole_1 = tkinter.Entry(okno)
wypelnienie.create_window(200, 100, window = pole_1)

etykieta_2 = tkinter.Label(okno, text = "Podaj druga liczbe")
wypelnienie.create_window(200, 120, window = etykieta_2)

pole_2 = tkinter.Entry(okno)
wypelnienie.create_window(200, 140, window = pole_2)

def dzialanie():
    zmienna_1 = pole_1.get()
    zmienna_2 = pole_2.get()
    
