import xml.etree.ElementTree as ET
import xmlrpc.client

url = 'http://localhost:8069'
DB = 'network'
USER = 'sbrudi@uoc.edu'
PASS = 'password'

common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
common.version()

models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})

if uid:
    archivo_xml = ET.parse('C:/Users/sergi/Documents/GitHub/NetWork/NetWork/Controlador/Reservas.xml')
    xml = archivo_xml.getroot()
    for i in xml:
        do_write = models.execute_kw(DB, uid, PASS, 'x_reservas', 'create', [{
            'x_studio_x_CodigoReservas': i[0].text,
            'x_studio_x_NumHabitacion': i[1].text,
            'x_studio_x_FechaEntrada': i[2].text,
            'x_studio_x_FechaSalida': i[3].text,
            'x_studio_x_IdCliente': i[4].text,
            'x_studio_x_EstadoReserva': i[5].text,
        }])
    print('Las reservas se han cargado correctamente')
else:
    print('Error en conexión')
