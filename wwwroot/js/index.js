/*
// Global state
const todos = [];
let deletedCount = 0;
let selectedFilter = "all";

// Hämtar element från DOM
const form = document.getElementById("todo-form");
const todoInput = document.getElementById("todo-input");
const todoList = document.getElementById("todo-list");
const emptyMessage = document.getElementById("empty-message");
const searchInput = document.getElementById("search-input");

//Lägger till ny todo
form.addEventListener("submit", (event) => {
    event.preventDefault();

    const title = todoInput.value.trim();

    if (!title) return;

    todos.push({
        id: crypto.randomUUID(),
        title,
        isCompleted: false
    });

    todoInput.value = "";
    render();
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

        item.querySelector("input").addEventListener("change", () => {
            todo.isCompleted = !todo.isCompleted;
            render();
        });

        item.querySelector(".delete-button").addEventListener("click", () => {
            const index = todos.findIndex((item) => item.id === todo.id);
            todos.splice(index, 1);
            deletedCount++;
            render();
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

render();*/