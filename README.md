# Contpaqi.Sdk.Contabilidad
Este repositorio contiene documentacion y ejemplos de como utilizar el SDK de CONTPAQi Contabilidad.

# Introduccion

## Que es el SDK?
* El SDK de Contabilidad es una librería COM proporcionada por CONTPAQi que nos permite interactuar con el sistema de CONTPAQi Contabilidad.
* El SDK expone interfaces de objectos y métodos que nos permite dar de alta y consultar datos e información implementando las reglas de negocio requeridas por el sistema de CONTPAQi Contabilidad.

## Por que usar el SDK en vez de trabajar directamente con la base de datos?
* Para dar de alta información directamente en la base de datos de CONTPAQi Contabilidad tendríamos que saber todas las reglas de negocio y tablas que se necesitan afectar. Esta información CONTPAQi no nos la proporciona y tampoco seria productivo tratar de averiguar.
* El SDK si implementa las reglas de negocio requeridas por el sistema.
* Donde si podemos trabajar directamente con la base de datos es en las consultas ya que el SDK no nos expone todos los métodos de consultas que pudiéramos necesitar y por experiencia es mas rápido hacer las consultas directamente a la base de datos.

## Requerimientos para usar el SDK
* Tener el SDK de Contabilidad instalado en la terminal donde se va a ejecutar la aplicación que consume el SDK.
* Si Contabilidad esta configurado en modo Servidor/Terminal, la terminal debe estar en la misma red y tener acceso al servidor.
* La aplicación a desarrollar debe poder consumir librerías COM, por lo que deben ser aplicaciones .Net utilizando el leguaje de programación de C#.
* La aplicación debe ser una aplicación de escritorio como de Windows Console App, Windows Forms, o Windows WPF.
* La aplicación a desarrollar debe ejecutarse en modo Administrador.

## Donde puedo encontrar documentación del SDK?
* Hasta el momento CONTPAQi no proporciona documentación oficial del SDK cuando se instala.
* Principalmente debemos utilizar el examinador de objectos de Visual Studio para visualizar los objectos y métodos que el SDK nos proporciona.
* Para preguntas y soporte podemos hacerlo dentro de los foros oficiales de CONTPAQI
* También pueden explorar este repositorio de Github donde podrán encontrar documentación y ejemplos.

# Curso Basico SDK CONTPAQi Contabilidad
Si buscan tutoriales y ejemplos de como desarrollar aplicaciones utilizando el SDK de CONTPAQi Contabilidad pueden hacerlo tomando nuestro [curso basico]((https://www.youtube.com/playlist?list=PLuJ1O2N9XXg6bXQI0lBp7kgAGSCJSUbVt)) disponible en YouTube

## Temario
1. [Introduccion](https://www.youtube.com/watch?v=I_UiYNof0DA&list=PLuJ1O2N9XXg6bXQI0lBp7kgAGSCJSUbVt&index=1)
1. [Iniciar Conexion](https://www.youtube.com/watch?v=jDXyUzx79JU&list=PLuJ1O2N9XXg6bXQI0lBp7kgAGSCJSUbVt&index=2)
