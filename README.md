1. Nombre del proyecto:
	
	PruebaZiur.
	Lista de movimientos de inventario consumido desde la API REST de Ziur.


2. Objetivo y alcance:
 
	Este programa permite realizar diferentes consultas de los movimientos del inventario de manera filtrada, mediante código, descripción o estado Activo/Inactivo. Puede ser en orden ascendente o descendente según lo requiera el usuario.
	Dentro de sus funcionalidades se incluyen consulta, grilla, búsqueda de movimientos, ordenamiento y estados de carga/error.


3. Tecnologías utilizadas:
	
	NET 8.0.
	Blazor Web App y modo de interactividad del servidor.
	Razor para la creación de componentes reutilizables.
	C# para la creación de modelos y servicios a utilizar dentro del programa.


4. Arquitectura:
	
	appsettings.json: Preparación del entorno dentro del cual se recibirán los datos del enpoint sin necesidad de exponer el token asignado.

	Program.cs: Registro y preparación de las configuraciones y servicios a utilizar al momento de obtener lo que haya dentro de la url de la Api de Ziur.

	Service: Sitio que alojará los servicios a utilizar. 
	  -Serviciocs.cs: Clase creada para capturar y asignar el token al cliente Http que fue creado.	  		

	Models: Carpeta para manejar los movimientos del inventario.
	  -InventarioDto.cs: Clase que hace la gestión de la lista de movimientos del inventario.		

	Components: Alojamiento de capas de navegación, y almacenamiento de paginas (componentes razor).
	  -Layout: 
	      MainLayout.razor -
		                     |
		                     | Componentes de navegación.
					         |
		  NavMenu.razor -----

	  -Pages: 
	      Error.razor ---
		                 |
		  Home.razor ----| Componentes para renderización de páginas.
					     | 
		  Prueba.razor --

	  -App.razor: Componente raiz sobre el cual se realizarán todas las conexiones.
 

5. Integración con la API:
    
	Se utilizó el Método HTTP AddHttpClient
	La URl se configura a través del constructor que utilizará la variable de entorno ZiurApi que recibirá lo que traiga la url de la API.
	El token se asigna a través de la Consola de Administración de paquetes con el fin de no exponer nuestro tokek.


6. Configuración y ejecución local:
	
	El endpoint se configura a través de la variable de entorno ZiurApi que contendrá baseurl, dicha variable se alojará en el archivo appsettings.json.
	Se reutiliza dicha variable de entorno para almacenar el token a través de la Consola Administradora de Paquetes y poder reutilizarlo en el archivo de servicios que hará el consumo del enpoint y del token
	sin necesidad de exponerlo.

	### Ejecución desde Visual Studio

    1. Abrir la solución.
    2. Configurar el endpoint de Ziur en `appsettings.json`.
	3. Configurar el token de acceso mediante User Secrets. No se debe guardar el token en el repositorio.
	4. Seleccionar el perfil de ejecución del proyecto en la barra superior.
	5. Ejecutar con **F5** para depurar o **Ctrl+F5** para ejecutar sin depuración.
	6. Abrir la ruta `/movimientos` para consultar el catálogo.

	### Desde la terminal

	1. Abrir una terminal en la carpeta donde se encuentra `PruebaZiur.csproj`.
	2. Ejecutar:

	```bash
	dotnet restore
	dotnet run


7. Uso de la aplicación:

    Se abre la pagina principl (Home Page)
	Damos click en la sección Movimientos para acceder a la pagina de catálogo
	Buscamos los registros a través de la sección de búsqueda para filtrar lso movimientos. Filtramos los registros por, codigo, descripción o estado. En orden ascendente o descendente.


8. Manejo de errores:

	InvalidOperationException:
	  Excepcion de Operacion Invalida.

	HttpRequestException: 
	  No fue posible conectar con el servicio. Verificar la URL y la conexión.

	JsonException: 
	  La respuesta recibida no tiene el formato esperado.


9. Seguridad:

    El token no se mostrará en el código, no se almacenará en el repositorio ni se mostrará en pantalla.
	

10. Autor y contacto
     Juan Pablo Alfonso Garcia
	 Teléfono: 314 371 0104
	 Correo: juan.alfonsogarcia0907@gmail.com
	


   


	
	



	