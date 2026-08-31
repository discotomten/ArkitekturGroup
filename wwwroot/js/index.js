// Global state
const todos = [];
let deletedTodos = [];
let deletedCount = 0;
let selectedFilter = "all";

// Hämtar element från DOM
const form = document.getElementById("todo-form");
const todoInput = document.getElementById("todo-input");
const todoList = document.getElementById("todo-list");
const emptyMessage = document.getElementById("empty-message");
const searchInput = document.getElementById("search-input");

// Lägger till en ny todo via C# backend
form.addEventListener("submit", async (event) => {
    event.preventDefault();

    // Hämtar texten från inputfältet
    const title = todoInput.value.trim();

    // Om inputfältet är tomt gör vi ingenting
    if (!title) return;

    // Skickar den nya todo:n till C# backend
    await fetch("/todos", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            description: title
        })
    });

    // Tömmer inputfältet
    todoInput.value = "";

    // Hämtar den uppdaterade listan från backend
    loadTodos();
});

// Söker efter todo
searchInput.addEventListener("input", render);

document.querySelectorAll(".filter").forEach((button) => {
    button.addEventListener("click", () => {
        selectedFilter = button.dataset.filter;

        document.querySelectorAll(".filter").forEach((item) => {
            item.classList.remove("active");
        });

        button.classList.add("active");
        render();
    });
});

// Hämtar alla todos från C# backend
async function loadTodos() {
    const response = await fetch("/todos");

    const data = await response.json();

    // Tömmer den lokala listan
    todos.length = 0;
    deletedTodos.length = 0;

    // Lägger in todos från backend
    data.filter(todo => todo.isDeleted === false)
    .forEach((todo) => {
        todos.push({
            id: todo.id,
            title: todo.description,
            isCompleted: todo.isFinished
        });
    });
    data.filter(todo => todo.isDeleted === true)
    .forEach((todo) => {
        deletedTodos.push({
            id: todo.id,
            title: todo.description,
            isCompleted: todo.isFinished 
        });
    });
    

    // Visar todos på sidan
    render();
}
// Renderar alla todos
function render() {
    const searchText = searchInput.value.toLowerCase();

    // Filtrerar todos baserat på söktext och vald filter
    const visibleTodos = todos.filter((todo) => {
        const matchesSearch = todo.title.toLowerCase().includes(searchText);
        const matchesFilter =
            selectedFilter === "all" ||
            (selectedFilter === "active" && !todo.isCompleted) ||
            (selectedFilter === "completed" && todo.isCompleted);

        return matchesSearch && matchesFilter;
    });

    todoList.innerHTML = "";

    // Skapar ny todo
    visibleTodos.forEach((todo) => {
        const item = document.createElement("li");
        item.className = `todo-item ${todo.isCompleted ? "completed" : ""}`;

        item.innerHTML = `
    <input type="checkbox" ${todo.isCompleted ? "checked" : ""}>
    <label>${todo.title}</label>
    <button class="delete-button">Ta bort</button>
`;

        // Uppdaterar todo när checkboxen ändras
        item.querySelector("input").addEventListener("change", async () => {

            // Ändrar status från klar till inte klar
            // eller från inte klar till klar
            todo.isCompleted = !todo.isCompleted;

            // Skickar ändringen till C# backend
            await fetch(`/todos/${todo.id}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    description: todo.title,
                    isFinished: todo.isCompleted
                })
            });

            // Hämtar todos från backend igen
            loadTodos();
        });

        // Tar bort todo via C# backend
        item.querySelector(".delete-button").addEventListener("click", async () => {

            // Skickar DELETE-request till backend med todo:ns id
            await fetch(`/todos/${todo.id}`, {
                method: "DELETE"
            });

            // Hämtar listan från backend igen
            loadTodos();
        });

        todoList.appendChild(item);
    });

    // Visar tom meddelande
    emptyMessage.hidden = visibleTodos.length > 0;

    // Uppdaterar statistik
    document.getElementById("created-count").textContent = todos.length + deletedCount;
    document.getElementById("completed-count").textContent =
        todos.filter((todo) => todo.isCompleted).length;
    document.getElementById("deleted-count").textContent = deletedCount;
}

// Startar programmet genom att hämta todos från backend
loadTodos();