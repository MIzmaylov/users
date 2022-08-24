
    // ��������� ���� �������������
    async function getUsers() {
            // ���������� ������ � �������� �����
            const response = await fetch("/api/users", {
        method: "GET",
    headers: {"Accept": "application/json" }
            });
    // ���� ������ ������ ���������
    if (response.ok === true) {
                // �������� ������
                const users = await response.json();
    const rows = document.querySelector("tbody");
                // ��������� ���������� �������� � �������
                users.forEach(user => rows.append(row(user)));
            }
        }
    // ��������� ������ ������������
    async function getUser(id) {
            const response = await fetch("/api/users/" + id, {
        method: "GET",
    headers: {"Accept": "application/json" }
            });
    if (response.ok === true) {
                const user = await response.json();
    const form = document.forms["userForm"];
    form.elements["id"].value = user.Id;
    form.elements["name"].value = user.Name;
    form.elements["phonenumber"].value = user.PhoneNumber;
            }
    else {
                // ���� ��������� ������, �������� ��������� �� ������
                const error = await response.json();
    console.log(error.message); // � ������� ��� �� �������
            }
        }
    // ���������� ������������
    async function createUser(userName, phone) {
 
            const response = await fetch("api/users", {
        method: "POST",
    headers: {"Accept": "application/json", "Content-Type": "application/json" },
    body: JSON.stringify({
        name: userName,
    phone: parseInt(phone, 10)
                })
            });
    if (response.ok === true) {
                const user = await response.json();
    reset();
    document.querySelector("tbody").append(row(user));
            }
    else {
                const error = await response.json();
    console.log(error.message);
            }
        }
    // ��������� ������������
    async function editUser(userId, userName, phone) {
            const response = await fetch("api/users", {
        method: "PUT",
    headers: {"Accept": "application/json", "Content-Type": "application/json" },
    body: JSON.stringify({
        id: userId,
    name: userName,
    phonenumber: parseInt(phone, 10)
                })
            });
    if (response.ok === true) {
                const user = await response.json();
    reset();
    document.querySelector("tr[data-rowid='" + user.id + "']").replaceWith(row(user));
            }
    else {
                const error = await response.json();
    console.log(error.message);
            }
        }
    // �������� ������������
    async function deleteUser(id) {
            const response = await fetch("/api/users/" + id, {
        method: "DELETE",
    headers: {"Accept": "application/json" }
            });
    if (response.ok === true) {
                const user = await response.json();
    document.querySelector("tr[data-rowid='" + user.id + "']").remove();
            }
    else {
                const error = await response.json();
    console.log(error.message);
            }
        }

    // ����� ������ ����� ����� ��������
    function reset() {
            const form = document.forms["userForm"];
    form.reset();
    form.elements["id"].value = 0;
        }
    // �������� ������ ��� �������
    function row(user) {
 
            const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", user.id);

    const nameTd = document.createElement("td");
    nameTd.append(user.name);
    tr.append(nameTd);

    const ageTd = document.createElement("td");
    ageTd.append(user.age);
    tr.append(ageTd);

    const linksTd = document.createElement("td");

    const editLink = document.createElement("a");
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("��������");
            editLink.addEventListener("click", e => {

        e.preventDefault();
    getUser(user.id);
            });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("�������");
            removeLink.addEventListener("click", e => {

        e.preventDefault();
    deleteUser(user.id);
            });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);

    return tr;
        }
        // ����� �������� �����
        document.getElementById("reset").addEventListener("click", e => {

        e.preventDefault();
    reset();
        })

        // �������� �����
        document.forms["userForm"].addEventListener("submit", e => {
        e.preventDefault();
    const form = document.forms["userForm"];
    const id = form.elements["id"].value;
    const name = form.elements["name"].value;
    const phonenumber = form.elements["phonenumber"].value;
    if (id == 0)
    createUser(name, phonenumber);
    else
    editUser(id, name, phonenumber);
        });

    // �������� �������������
    getUsers();
