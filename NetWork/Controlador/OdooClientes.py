import xml.etree.ElementTree as ET
import xmlrpc.client

url = 'http://localhost:8069'
DB = 'network'
USER = 'sbrudi@uoc.edu'
PASS = 'password'

common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
common.version()

# Objeto XML-RPC para manipular datos en el servidor
models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})

if uid:
    archivo_xml = ET.parse('C:/Users/sergi/Desktop/GIT/Network/NetWork/Controlador/Clientes.xml')
    xml = archivo_xml.getroot()
    for cliente in xml.findall('Cliente'):  # Acceder a los elementos Cliente
        cliente_data = {
            'x_studio_x_nif': cliente.attrib['DNI'],
            'x_studio_x_nombre': cliente.attrib['Nombre'],
            'x_studio_x_telfono': cliente.attrib['Teléfono'],
            'x_studio_x_mail': cliente.attrib['Email'],
            'x_studio_x_contrasena': '',  # No hay contraseña en el XML original
        }
        # Crear el cliente en el servidor
        do_write = models.execute_kw(DB, uid, PASS, 'x_clientes', 'create', [cliente_data])
    print('Los clientes se han cargado correctamente')
else:
    print('Error en la conexión')
