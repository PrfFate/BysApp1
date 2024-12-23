function showSection(sectionId) {
    const sections = document.querySelectorAll(".section");
    const menuItems = document.querySelectorAll(".nav-item");

    sections.forEach(section => section.style.display = "none");
    document.getElementById(sectionId).style.display = "block";

    menuItems.forEach(menuItem => menuItem.classList.remove("active"));
    document.querySelector(`[onclick="showSection('${sectionId}')"]`).classList.add("active");

    localStorage.setItem("activeSection", sectionId);
}

document.addEventListener("DOMContentLoaded", () => {
    const activeSection = localStorage.getItem("activeSection") || "duyurular";
    showSection(activeSection);
});

let selectedCourses = [];
function toggleSelection(element, courseId) {
    if (element.classList.contains("selected")) {
        element.classList.remove("selected");
        selectedCourses = selectedCourses.filter(id => id !== courseId);
    } else {
        element.classList.add("selected");
        selectedCourses.push(courseId);
    }
}

function toggleCourseSelection(element, courseId) {
    const checkbox = element.querySelector('input[type="checkbox"]');
    const isMandatory = checkbox.classList.contains('mandatory-checkbox');
    checkbox.checked = !checkbox.checked;

    if (isMandatory) {
        const mandatoryCheckboxes = document.querySelectorAll('.mandatory-checkbox');
        const selectedCount = Array.from(mandatoryCheckboxes).filter(cb => cb.checked).length;

        if (selectedCount > 4) {
            alert('Zorunlu derslerden en fazla 4 adet seçebilirsiniz.');
            checkbox.checked = false;
            return;
        }
    }

    if (checkbox.checked) {
        element.classList.add('selected');
    } else {
        element.classList.remove('selected');
    }
}

function confirmCourseSelection() {
    if (selectedCourses.length === 0) {
        alert("Lütfen en az bir ders seçin.");
        return;
    }

    fetch('/Student/SubmitCourseSelections', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(selectedCourses)
    })
        .then(response => {
            if (response.ok) {
                alert("Ders seçimi başarıyla kaydedildi!");
                location.reload();
            } else {
                alert("Ders seçimi sırasında bir hata oluştu.");
            }
        })
        .catch(error => {
            console.error("Hata:", error);
            alert("Ders seçimi sırasında bir hata oluştu.");
        });
}

document.addEventListener("DOMContentLoaded", () => {
    const courseList = document.getElementById("courseList");
    const form = document.getElementById("courseSelectionForm");

    courseList.addEventListener("click", event => {
        const clickedElement = event.target.closest(".course-option");
        if (clickedElement) {
            const checkbox = clickedElement.querySelector("input[type='checkbox']");
            checkbox.checked = !checkbox.checked;
            clickedElement.classList.toggle("selected", checkbox.checked);
        }
    });

    form.addEventListener("submit", event => {
        const selectedCourses = document.querySelectorAll("input[name='selectedCourseIds']:checked");
        if (selectedCourses.length === 0) {
            event.preventDefault();
            alert("Lütfen en az bir ders seçin.");
        }
    });
});

function logout() {
    window.location.href = '/';
}
