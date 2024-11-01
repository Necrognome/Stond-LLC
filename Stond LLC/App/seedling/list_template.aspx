﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list_template.aspx.vb" Inherits="App_seedling_Default" %>
<link href="https://unpkg.com/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
<!DOCTYPE html>
<link href="../../CSS/list_template.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <%--<h1>XML and XSLT Example</h1>
   <p>The following content is generated from an XML file:</p>
   <iframe src="..\Xml\Products.xml"></iframe>--%>


   <div class="h-100 w-full flex items-center justify-center bg-teal-lightest font-sans mt-20">
       <div class="bg-white rounded shadow p-6 m-4 w-full lg:w-3/4 lg:max-w-lg">
           <div class="mb-4">
               <h1 class="text-3xl md:text-4xl text-indigo-600 font-medium mb-2">
                   To-Do List App
               </h1>
               <div class="flex mt-4">
                   <input class="shadow appearance-none border rounded w-full py-2 px-3 mr-4 text-grey-darker" name="text" id="text" placeholder="Add Todo" />
                   <input type="hidden" id="saveIndex" />
                   <button class="p-2 lg:px-4 md:mx-2 text-center border border-solid border-indigo-600 rounded text-white bg-indigo-600 transition-colors duration-300 mt-1 md:mt-0 md:ml-1" id="add-task-btn">Add</button>
                   <button class="p-2 lg:px-4 md:mx-2 text-center border border-solid border-indigo-600 rounded bg-indigo-600 text-white transition-colors duration-300 mt-1 md:mt-0 md:ml-1" style="display: none" id="save-todo-btn">Edit Todo</button>
               </div>
           </div>
           <div id="listBox"></div>
       </div>
   </div>
   <%--<button id="submit">Submit</button>--%>
</body>
</html>


<script>
    const submitButton = document.getElementById("submit");
    submitButton.addEventListener("click", () => {
        alert("The form has been submitted");
    });
    const text = document.getElementById("text");
    const addTaskButton = document.getElementById("add-task-btn");
    const saveTaskButton = document.getElementById("save-todo-btn");
    const listBox = document.getElementById("listBox");
    const saveInd = document.getElementById("saveIndex");

    let todoArray = [];

    addTaskButton.addEventListener("click", (e) => {
        e.preventDefault();
        let todo = localStorage.getItem("todo");
        if (todo === null) {
            todoArray = [];
        } else {
            todoArray = JSON.parse(todo);
        }
        todoArray.push(text.value);
        text.value = "";
        localStorage.setItem("todo", JSON.stringify(todoArray));
        displayTodo();
    });

    function displayTodo() {
        let todo = localStorage.getItem("todo");
        if (todo === null) {
            todoArray = [];
        } else {
            todoArray = JSON.parse(todo);
        }
        let htmlCode = "";
        todoArray.forEach((list, ind) => {
            htmlCode += `<div class='flex mb-4 items-center'>
<p class='w-full text-grey-darkest'>${list}</p>
<button onclick='edit(${ind})' class='flex-no-shrink p-2 ml-4 mr-2 border-2 rounded text-white text-grey bg-green-600'>Edit</button>
<button onclick='deleteTodo(${ind})' class='flex-no-shrink p-2 ml-2 border-2 rounded text-white bg-red-500'>Delete</button>
</div>`;
        });
        listBox.innerHTML = htmlCode;
    }


    function deleteTodo(ind) {
        let todo = localStorage.getItem("todo");
        todoArray = JSON.parse(todo);
        todoArray.splice(ind, 1);
        localStorage.setItem("todo", JSON.stringify(todoArray));
        displayTodo();
    }

    function edit(ind) {
        saveInd.value = ind;
        let todo = localStorage.getItem("todo");
        todoArray = JSON.parse(todo);
        text.value = todoArray[ind];
        addTaskButton.style.display = "none";
        saveTaskButton.style.display = "block";
    }

    saveTaskButton.addEventListener("click", () => {
        let todo = localStorage.getItem("todo");
        todoArray = JSON.parse(todo);
        let id = saveInd.value;
        todoArray[id] = text.value;
        addTaskButton.style.display = "block";
        saveTaskButton.style.display = "none";
        text.value = "";
        localStorage.setItem("todo", JSON.stringify(todoArray));
        displayTodo();
    });
</script>