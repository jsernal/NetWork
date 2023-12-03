from ast import Attribute
import xml.etree.ElementTree as ET
import xmlrpc.client

url = 'https://network4.odoo.com/'
DB = 'network4'
USER = 'sbrudi@uoc.edu'
PASS = 'password'

common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
common.version()

models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})

if uid:
    archivo_xml = ET.parse('C:/Users/sergi/Documents/GitHub/NetWork/NetWork/Controlador/Reservas.xml')
    xml = archivo_xml.getroot()

    # Iterar sobre los elementos del XML y enviar a Odoo
    for reserva in xml:
     reserva_data = {
        'x_studio_x_codigoreservas': reserva.attrib['CodigoReservas'],
        'x_studio_x_numhabitacion':  reserva.attrib['NumHabitacion'],
        'x_studio_x_fechaentrada':  reserva.attrib['FechaEntrada'],
        'x_studio_x_fechasalida':  reserva.attrib['FechaSalida'],
        'x_studio_x_idcliente':  reserva.attrib['IdCliente'],
        'x_studio_x_estadoreserva': reserva.attrib['EstadoReserva'],
        'x_name': reserva.attrib['CodigoReservas'],
    }
    do_write = models.execute_kw(DB, uid, PASS, 'x_reservas', 'create', [reserva_data])

    print('Las reservas se han cargado correctamente')
else:
    print('Error en conexión')
