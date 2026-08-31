// Hämtar statistik från C# backend
async function loadStatistics() {

    // Hämtar statistik från /Statistics
    const response = await fetch("/Statistics");

    // Gör om JSON-svaret till JavaScript-data
    const data = await response.json();

    // Visar antal skapade todos
    document.getElementById("created-count").textContent =
        data.createdCount;

    // Visar antal klara todos
    document.getElementById("completed-count").textContent =
        data.completedCount;

    // Visar antal borttagna todos
    document.getElementById("deleted-count").textContent =
        data.deletedCount;
}


// Startar hämtningen av statistik
loadStatistics();