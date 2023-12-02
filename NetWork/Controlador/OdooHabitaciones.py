import xml.etree.ElementTree as ET
import xmlrpc.client

# URL y credenciales de la base de datos de Odoo
url = 'https://netwok.odoo.com/'
DB = 'netwok'
USER = 'sbrudi@uoc.edu'
PASS = 'password'

# Conexión XML-RPC
common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})

if uid:
    # Ruta del archivo XML
    xml_file_path = 'C:/Users/sergi/Documents/GitHub/NetWork/NetWork/Controlador/Habitaciones.xml'

    # Parsear el archivo XML
    tree = ET.parse(xml_file_path)
    root = tree.getroot()

    # Iterar sobre los elementos del XML y enviar a Odoo
    for habitacion in root.findall('Habitacion'):
        habitacion_data = {
            'x_studio_x_numhabitacion': habitacion.find('Numero').text,
            'x_studio_x_estado': habitacion.find('Estado').text,
            'x_studio_x_tipo': habitacion.find('Tipo').text,
        }

        # Crear la habitación en el servidor Odoo
        try:
            created_room = models.execute_kw(DB, uid, PASS, 'x_habitaciones', 'create', [habitacion_data])
            print(f"Habitación creada con ID: {created_room}")
        except Exception as e:
            print(f"Error al crear la habitación: {e}")
else:
    print('Error en la conexión')
    
input("Presiona Enter para salir...")
