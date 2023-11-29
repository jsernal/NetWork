import xml.etree.ElementTree as ET
import xmlrpc.client

url = 'http://localhost:8069'
DB='Network'
USER='sbrudi@uoc.edu'
PASS='password'

common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
common.version()

#object = xmlrpc.client.ServerProxy(url+'object')
models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})

if uid:
    archivo_xml = ET.parse('C:/Users/sergi/Documents/GitHub/NetWork/NetWork/Controlador/Habitaciones.xml')
    xml = archivo_xml.getroot()
    for i in xml:
        do_write = models.execute(DB,uid,PASS,'x_actividades','create',[{
            'x_studio_x_NumHabitacion': i[0].text,
            'x_studio_x_Estado': i[1].text,
            'x_studio_x_Tipo': i[2].text,
            }])
    print('Las actividades se han cargado correctamente')
else:
    print('Error en conexión')