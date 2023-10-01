# TP Integrador Softtek
El proyecto está desarrollado con Net Core 6 y SQL SERVER para la base de datos.
​
## **Para iniciar**
Una vez descargado del github abrir con visual studio, cambiar ubicación del archivo de documentación : en el explorador de soluciones click derecho en el proyecto->Propiedades->Aplicacion->General->Salida->Ruta de acceso del archivo de documantación XML.

Agregar appsettings.json siguiendo el ejemplo del archivo appsettings.json.example.

## **Especificación de la Arquitectura**
​
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible.
​
### **Capa DataAccess**
Es donde definiremos el DbContext y crearemos los seeds correspondientes para armar nuestras entidades.
​
### **Capa Models**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Repositories**
En esta capa definiremos las clases correspondientes para realizar el repositorio genérico.

### **Capa Services**
En esta capa definiremos las clases correcpondientes para utilzar el patron unit of work.

### **Capa Helper**
Definiremos lógica que pueda ser de utilidad para todo el proyecto. Por ejemplo, algún método para encriptar/desencriptar contraseñas.

### **Capa Infrastruture**
En esta capa definiremos la estructura de las respuestas, tanto si la operación se realizó con éxito como también si esta dio error.

### **Capa DTOs**
Esta capa se encargará de ayudar a encapsular y transferir datos de las entidades para que solo se expongan los datos que sean necesarios para la operación.
​
## **Especificación de GIT**
​
* Se deberán crear las ramas a partir de 'develop'. 
* La nomenclatura para el nombre de las ramas será la siguiente: Feature/[NombreRama].
* Los commits deben llevar descripciones.
