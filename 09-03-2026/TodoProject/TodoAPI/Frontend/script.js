const apiUrl = "http://localhost:5014/api/todo";

let currentFilter = "all";

function loadTasks(){

fetch(apiUrl)
.then(res => res.json())
.then(data => {

let list = document.getElementById("taskList");
list.innerHTML="";

let filtered = data;

if(currentFilter === "active")
filtered = data.filter(t => !t.isCompleted);

if(currentFilter === "completed")
filtered = data.filter(t => t.isCompleted);

filtered.forEach(task => {

let li = document.createElement("li");

let color="purple";

if(task.priority==="High") color="red";
if(task.priority==="Low") color="green";

li.innerHTML = `
<input type="checkbox" ${task.isCompleted ? "checked" : ""} 
onclick="toggleComplete(${task.id}, '${task.task}', ${task.isCompleted}, '${task.priority}')">

<span style="${task.isCompleted ? 'text-decoration:line-through' : ''}; color:${color}">
${task.task} (${task.priority})
</span>

<div>
<button onclick="editTask(${task.id}, '${task.task}', ${task.isCompleted}, '${task.priority}')">Edit</button>
<button onclick="deleteTask(${task.id})">Delete</button>
</div>
`;

list.appendChild(li);

});

});
}

function addTask(){

let task = document.getElementById("taskInput").value;
let priority = document.getElementById("priority").value;

if(task.trim()===""){
alert("Enter task");
return;
}

fetch(apiUrl,{
method:"POST",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify({
task:task,
priority:priority,
isCompleted:false
})
})
.then(()=>{
document.getElementById("taskInput").value="";
loadTasks();
});

}

function deleteTask(id){

fetch(apiUrl+"/"+id,{
method:"DELETE"
})
.then(()=>loadTasks());

}

function toggleComplete(id,task,status,priority){

fetch(apiUrl+"/"+id,{
method:"PUT",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify({
id:id,
task:task,
priority:priority,
isCompleted:!status
})
})
.then(()=>loadTasks());

}

function editTask(id,oldTask,status,priority){

let newTask = prompt("Edit Task", oldTask);

if(newTask==null) return;

fetch(apiUrl+"/"+id,{
method:"PUT",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify({
id:id,
task:newTask,
priority:priority,
isCompleted:status
})
})
.then(()=>loadTasks());

}

function filterTasks(type){

currentFilter=type;
loadTasks();

}

function searchTasks(){

let input=document.getElementById("searchBox").value.toLowerCase();
let tasks=document.querySelectorAll("#taskList li");

tasks.forEach(task=>{

let text=task.innerText.toLowerCase();
task.style.display=text.includes(input)?"flex":"none";

});

}

function toggleDarkMode(){

document.body.classList.toggle("dark");

}

loadTasks();