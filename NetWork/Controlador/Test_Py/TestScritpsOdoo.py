# test_odoo_connector.py
# -*- coding: utf-8 -*-
import unittest
from unittest.mock import patch
from odoo_connector import conectar_odoo, obtener_datos
import unittest
import xmlrpc.client
import xml.etree.ElementTree as ET

class TestOdooIntegration(unittest.TestCase):

    def setUp(self):
        # Configuración común antes de cada prueba
        self.url = 'https://network4.odoo.com/'
        self.DB = 'network4'
        self.USER = 'sbrudi@uoc.edu'
        self.PASS = 'password'

    def test_odoo_integration(self):
        # Configuración específica de la prueba
        common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(self.url))
        models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(self.url))

        # Prueba de conexión
        try:
            version = common.version()
            self.assertIsNotNone(version)
        except Exception as e:
            print(f'Error en la conexipn: {e}')
            self.fail('Error en la conexion')

        # Prueba de autenticación
        try:
            uid = common.authenticate(self.DB, self.USER, self.PASS, {})
            self.assertIsNotNone(uid)
        except Exception as e:
            self.fail(f'Error en la autenticacion: {e}')

        # Prueba de creación de clientes
        archivo_xml = ET.parse('C:/Users/JesusSernaLlansama/source/jsernal/NetWork/NetWork/Controlador/Clientes.xml')
        xml = archivo_xml.getroot()
        errores = False

        for cliente in xml.findall('Cliente'):
            cliente_data = {
                'x_studio_x_idcliente': cliente.attrib['idCliente'],
                'x_studio_x_nombre': cliente.attrib['Nombre'],
                'x_studio_x_telefono': cliente.attrib['Telefono'],
                'x_studio_x_nif': cliente.attrib['DNI'],
                'x_studio_x_mail': cliente.attrib['Email'],
                'x_studio_x_tipo': cliente.attrib['Tipo'],
                'x_name': cliente.attrib['Nombre'],
            }

            # Prueba de creación de cliente en el servidor
            try:
                do_write = models.execute_kw(self.DB, uid, self.PASS, 'x_clientes', 'create', [cliente_data])
                self.assertIsNotNone(do_write)
                print(f'Cliente {cliente.attrib["idCliente"]} creado exitosamente')
            except Exception as e:
                print(f'Error al crear el cliente {cliente.attrib["idCliente"]}: {e}')
                errores = True

        if not errores:
            print('Los clientes se han cargado correctamente')
        else:
            self.fail('Se produjeron errores al cargar los clientes')

if __name__ == '__main__':
    unittest.main()