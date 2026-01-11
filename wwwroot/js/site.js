const api = "api/Problem"
let todos = [];

function addItem(event)
{
event.preventDefault();

    const titleInput = document.getElementById("add-name")
    const item = {
        name: titleInput.value.trim()
    };
    fetch(api,
        {
            method: "POST",
            headers: {
                "Accept" : "application/json",
                "Content-Type" : "application/json"
            },
            body: JSON.stringify(item)
        })
        .then(response=> response.json())
        .then( () => {

            GetItems();
            titleInput.value = " ";
        })
        .catch(error => console.error("unable to add item.",error));

}
    
function UpdateItem(event)
{
    event.preventDefault();
}
function GetItems()
{
    fetch(api)
    .then( response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error("Не получилось получить список задач"));
}
function closeInput()
{

}

function _displayCount()
{

    const name = (imetCount ===1) ? "сделать задачу: " : "сделать задачи: ";
    document.getElementById("counter").innerText = `${item.count} ${name}`;
}

function _displayItems(data)
{
    const tbody = document.getElementById("prob");
    tbody.innerHTML = '';
    _displayCount();
    const button = document.createElement("button")
    
    data.forEach(item => {
        let IsCompleteCheckBox = document.createElement("input");
        // тут добавить состояния чекбокса
        let editButton = button.cloneNode(none);
        editButton.inneText = "Edit";
        editButton.Attribute("onclick",`displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        editButton.InnerText = "Delete";
        editButton.Attribute("onclick",`deleteItem(${item.id})`);

        let tr = tbody.insertRow();
        // тут не забудь добавить данные для чекбоска завершенно или нет
        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.name);
        td2.appendChild(textNode);
        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);
        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });


    todos = data;


}