import xml.etree.ElementTree as ET
import xmlrpc.client


url = 'https://network4.odoo.com/'
DB = 'network4'
USER = 'sbrudi@uoc.edu'
PASS = 'password'

common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
common.version()

# Objeto XML-RPC para manipular datos en el servidor
models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
uid = common.authenticate(DB, USER, PASS, {})
if uid:
    archivo_xml = ET.parse('C:/Users/sergi/Documents/GitHub/NetWork/NetWork/Controlador/Clientes.xml')

    xml = archivo_xml.getroot()
    errores = False
    for cliente in xml.findall('Cliente'):  # Acceder a los elementos Cliente
        cliente_data = {
            'x_studio_x_idcliente': cliente.attrib['idCliente'],
            'x_studio_x_nombre': cliente.attrib['Nombre'],
            'x_studio_x_telefono': cliente.attrib['Telefono'],
            'x_studio_x_nif': cliente.attrib['DNI'],
            'x_studio_x_mail': cliente.attrib['Email'],
            'x_studio_x_tipo': cliente.attrib['Tipo'],
            'x_name': cliente.attrib['Nombre'],
        }
        # Crear el cliente en el servidor
        try:
            do_write = models.execute_kw(DB, uid, PASS, 'x_clientes', 'create', [cliente_data])
            print(f'Cliente {cliente.attrib["idCliente"]} creado exitosamente')
        except Exception as e:
            print(f'Error al crear el cliente {cliente.attrib["idCliente"]}: {e}')
            errores = True  # Indica que hubo errores al crear clientes
    if not errores:
        print('Los clientes se han cargado correctamente')
    else:
        print('Se produjeron errores al cargar los clientes')
else:
    print('Error en la conexión')

