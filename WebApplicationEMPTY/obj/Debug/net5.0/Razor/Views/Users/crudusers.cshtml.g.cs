#pragma checksum "D:\Загрузки\Учеба\inception\sharp\WebApplicationEMPTY\WebApplicationEMPTY\Views\Users\crudusers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30c54539a3cc9aaf7d05440a3c0875eb7ec68aac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_crudusers), @"mvc.1.0.view", @"/Views/Users/crudusers.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30c54539a3cc9aaf7d05440a3c0875eb7ec68aac", @"/Views/Users/crudusers.cshtml")]
    #nullable restore
    public class Views_Users_crudusers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Загрузки\Учеба\inception\sharp\WebApplicationEMPTY\WebApplicationEMPTY\Views\Users\crudusers.cshtml"
  
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
 <h2>Список пользователей</h2>
    <form name=""userForm"">
    <input type=""hidden"" name=""id"" value=""0"" />
        <div class=""mb-3"">
            <label class=""form-label"" for=""name"">Имя:</label>
            <input class=""form-control"" name=""name"" />
        </div>
        <div class=""mb-3"">
            <label for=""phonenumber"" class=""form-label"">phone:</label>
            <input class=""form-control"" name=""phonenumber"" />
        </div>
        <div class=""mb-3"">
            <button type=""submit"" class=""btn btn-sm btn-primary"">Сохранить</button>
            <a id=""reset"" class=""btn btn-sm btn-primary"">Сбросить</a>
        </div>
        

    </form>
<table class=""table table-condensed table-striped table-bordered"">
    <thead><tr><th>Имя</th><th>phone</th><th></th></tr></thead>
    <tbody>
    </tbody>
</table>
<script>
 // Получение всех пользователей
    async function getUsers() {
            // отправляет запрос и получаем ответ
            const respons");
            WriteLiteral(@"e = await fetch(""/api/users"", {
        method: ""GET"",
    headers: {""Accept"": ""application/json"" }
            });
    // если запрос прошел нормально
    if (response.ok === true) {
                // получаем данные
                const users = await response.json();
    const rows = document.querySelector(""tbody"");
                // добавляем полученные элементы в таблицу
                users.forEach(user => rows.append(row(user)));
            }
        }
    // Получение одного пользователя
    async function getUser(id) {
            const response = await fetch(""/api/users/"" + id, {
        method: ""GET"",
    headers: {""Accept"": ""application/json"" }
            });
    if (response.ok === true) {
                const user = await response.json();
    const form = document.forms[""userForm""];
    form.elements[""id""].value = user.id;
    form.elements[""name""].value = user.name;
    form.elements[""phonenumber""].value = user.phonenumber;
            }
    else {
             ");
            WriteLiteral(@"   // если произошла ошибка, получаем сообщение об ошибке
                const error = await response.json();
    console.log(error.message); // и выводим его на консоль
            }
        }
    // Добавление пользователя
    async function createUser( userName, phone) {
 
            const response = await fetch(""/users/api/"", {
        method: ""POST"",
    headers: {""Accept"": ""application/json"", ""Content-Type"": ""application/json"" },
    body: JSON.stringify({
              
        name: userName,
    phonenumber: phone })
            });
    if (response.ok === true) {
                const user = await response.json();
    reset();
    document.querySelector(""tbody"").append(row(user));
            }
    else {
                const error = await response.json();
    console.log(error.message);
            }
            
    }
    // Изменение пользователя
    async function editUser(userId, userName, phone) {
            const response = await fetch(""api/users"", {
        ");
            WriteLiteral(@"method: ""PUT"",
    headers: {""Accept"": ""application/json"", ""Content-Type"": ""application/json"" },
    body: JSON.stringify({
        id: userId,
    name: userName,
    phonenumber: phone
                })
            });
    if (response.ok === true) {
                const user = await response.json();
    reset();
    document.querySelector(""tr[data-rowid='"" + user.id + ""']"").replaceWith(row(user));
            }
    else {
                const error = await response.json();
    console.log(error.message);
            }
        }
    // Удаление пользователя
    async function deleteUser(id) {
            const response = await fetch(""/api/users/"" + id, {
        method: ""DELETE"",
    headers: {""Accept"": ""application/json"" }
            });
    if (response.ok === true) {
                const user = await response.json();
    document.querySelector(""tr[data-rowid='"" + user.id + ""']"").remove();
           
    }
    else {
                const error = await response.json();");
            WriteLiteral(@"
    console.log(error.message);
            }
        
    }

    // сброс данных формы после отправки
    function reset() {
            const form = document.forms[""userForm""];
    form.reset();
    form.elements[""id""].value = 0;
        }
    // создание строки для таблицы
    function row(user) {
 
            const tr = document.createElement(""tr"");
    tr.setAttribute(""data-rowid"", user.id);

    const nameTd = document.createElement(""td"");
    nameTd.append(user.name);
    tr.append(nameTd);

    const ageTd = document.createElement(""td"");
    ageTd.append(user.phonenumber);
    tr.append(ageTd);

    const linksTd = document.createElement(""td"");

    const editLink = document.createElement(""a"");
    editLink.setAttribute(""style"", ""cursor:pointer;padding:15px;"");
    editLink.append(""Изменить"");
            editLink.addEventListener(""click"", e => {

        e.preventDefault();
    getUser(user.id);
            });
    linksTd.append(editLink);

    const removeLink");
            WriteLiteral(@" = document.createElement(""a"");
    removeLink.setAttribute(""style"", ""cursor:pointer;padding:15px;"");
    removeLink.append(""Удалить"");
            removeLink.addEventListener(""click"", e => {

        e.preventDefault();
    deleteUser(user.id);
            });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);

    return tr;
        }
        // сброс значений формы
        document.getElementById(""reset"").addEventListener(""click"", e => {

        e.preventDefault();
    reset();
        })

        // отправка формы
        document.forms[""userForm""].addEventListener(""submit"", e => {
        e.preventDefault();
    const form = document.forms[""userForm""];
    const id = form.elements[""id""].value;
    const name = form.elements[""name""].value;
    const phonenumber = form.elements[""phonenumber""].value;
    
        if (id == 0)
            createUser(name, phonenumber);
        else
            editUser(id, name, phonenumber);
   
        });

    // загрузка по");
            WriteLiteral("льзователей\r\n    getUsers();\r\n</script>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
