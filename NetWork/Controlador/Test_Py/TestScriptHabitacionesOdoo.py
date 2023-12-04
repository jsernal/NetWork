import unittest
from unittest.mock import patch, Mock
from io import StringIO
import xml.etree.ElementTree as ET
import xmlrpc.client
from tu_modulo import tu_metodo  

class TestScript(unittest.TestCase):

    @patch('builtins.print', side_effect=lambda *args, **kwargs: None)
    def test_crear_habitaciones(self, mock_print):
    
        with patch('xmlrpc.client.ServerProxy') as mock_server_proxy:
          
            mock_common = mock_server_proxy.return_value
            mock_common.authenticate.return_value = 1

          
            mock_models = mock_server_proxy.return_value
            mock_models.execute_kw.return_value = 123  

            archivo_xml = ET.fromstring('''
                <Habitaciones NumHabitacion="101" Estado="Disponible" Tipo="Individual"/>
                <Habitaciones NumHabitacion="102" Estado="Ocupada" Tipo="Doble"/>
            ''')

       
            with patch('sys.stdout', new_callable=StringIO) as mock_stdout:
               
                tu_metodo(archivo_xml)

           
            expected_output = "Habitación creada con ID: 123\nHabitación creada con ID: 123\n"
            self.assertEqual(mock_stdout.getvalue(), expected_output)

         
            mock_print.assert_has_calls([
                mock.call('Habitación creada con ID: 123'),
                mock.call('Habitación creada con ID: 123')
            ])

            
            mock_models.execute_kw.assert_called_with('network4', 1, 'password', 'x_habitaciones', 'create', [
                {'x_studio_x_numhabitacion': '101', 'x_studio_x_estado': 'Disponible', 'x_studio_x_tipo': 'Individual', 'x_name': '101'},
                {'x_studio_x_numhabitacion': '102', 'x_studio_x_estado': 'Ocupada', 'x_studio_x_tipo': 'Doble', 'x_name': '102'}
            ])

if __name__ == '__main__':
    unittest.main()
