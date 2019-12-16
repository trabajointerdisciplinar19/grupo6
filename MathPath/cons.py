import sys
import sqlite3
import os
con = sqlite3.connect('Assets\Plugins\juego.db')
cursorObj = con.cursor()
cursorObj.execute('SELECT usuario.nickname,registro.notaal FROM registro inner join usuario on usuario.nickname=registro.Nickalumno')
rows = cursorObj.fetchall()
for i in rows:
    print(i)
