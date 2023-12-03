import xml.etree.ElementTree as ET
import xmlrpc.client

# URL y credenciales de la base de datos de Odoo
url = 'https://network4.odoo.com/'
DB = 'network4'
USER = 'sbrudi@uoc.edu'
PASS = 'password'

# Conexión XML-RPC
common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})

if uid:
    # Ruta del archivo XML
    archivo_xml = ET.parse('C:/Users/sergi/Documents/GitHub/NetWork/NetWork/Controlador/Habitaciones.xml')

    xml = archivo_xml.getroot()

    # Iterar sobre los elementos del XML y enviar a Odoo
    for habitacion in xml.findall('Habitaciones'):
        habitacion_data = {
            'x_studio_x_numhabitacion': habitacion.attrib['NumHabitacion'],
            'x_studio_x_estado': habitacion.attrib['Estado'],
            'x_studio_x_tipo': habitacion.attrib['Tipo'],
            'x_name': habitacion.attrib['NumHabitacion'],
        }

        # Crear la habitación en el servidor Odoo
        try:
            created_room = models.execute_kw(DB, uid, PASS, 'x_habitaciones', 'create', [habitacion_data])
            print(f"Habitación creada con ID: {created_room}")
        except Exception as e:
            print(f"Error al crear la habitación: {e}")
else:
    print('Error en la conexión')