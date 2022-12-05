# 🔥 Blazor.LabelFor 🔥
Un componente de blazor similar a Html.DisplayFor con funcionalidad añadida

## ⚙️ Requisitos ⚙️
_**Blazor.LabelFor** está construido sobre:_
```
● Sistema operativo: Windows 10
● Entorno de desarrollo: Visual Studio 2022
● Framework: NET 7
● Tecnología: Blazor
```

## 📋 Funcionalidades 📋
_Las funcionalidades actuales de **Blazor.LabelFor** son las siguientes:_
```
- Añadir un carácter al final del texto del atributo DisplayName (como un *) si esta definido como [Required]
- Añadir una clase HTML si esta definido como [Required]
- Uso de ambas posibilidades anteriores al mismo tiempo
```

## 📋 Funcionalidades 📋
_Ejemplos de uso de **Blazor.LabelFor**:_
```
<LabelFor class="form-label" For="@(() => {MODELO}.[PARAMETRO])" RequiredCharacter="*" RequiredClass="fw-bold" /> // Uso del carácter "@"*" y de la clase "fw-bold"
<LabelFor class="form-label" For="@(() => {MODELO}.[PARAMETRO])" RequiredCharacter="*" />  // Uso del carácter "@"*"
<LabelFor class="form-label" For="@(() => {MODELO}.[PARAMETRO])" RequiredClass="fw-bold" />  // Uso de la clase "fw-bold"
```

## 👨‍💻 Desarrolladores 👨‍💻
_**Blazor.LabelFor** es posible gracias a:_
* [**Luis Luzuriaga**](https://github.com/B1ON1C)