const tblBlog = "blogs";
let blogId = null;

getBlogTable();

// createBlog();
// updateBlog("dcec69f8-ec35-4828-aabe-b607d9f7f777","adfadfadfa","afasadsfasfq34frdsf","afasdfew");
deleteBlog("8a3b9dda-d63b-4051-b95f-e370d3062e3a");

function readBlog() {
  let lst = getBlogs();
  console.log(lst);
}

function editBlog(id) {
  let lst = getBlogs();
  const items = lst.filter((x) => x.id === id);
  console.log(items);

  console.log(items.length);

  if (items.length == 0) {
    console.log("No Data Fount");
    errorMessage("No Data fount");
    return;
  }
  // return items[0];
  let item = items[0];

  blogId = item.id;
  $("#txtTitle").val(item.title);
  $("#txtAuthor").val(item.author);
  $("#txtContent").val(item.content);
  $("#txtTitle").focus();
}

function createBlog(title, author, content) {
  let lst = getBlogs();

  const requestModel = {
    id: uuidv4(),
    title: title,
    author: author,
    content: content,
  };
  lst.push(requestModel);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem("blogs", jsonBlog);

  successMessage("Save SuccessFul!");
  clearControls();
}

function updateBlog(id, title, author, content) {
  let lst = getBlogs();
  const items = lst.filter((x) => x.id === id);
  console.log(items);

  console.log(items.length);

  if (items.length == 0) {
    console.log("No Data Fount");
    errorMessage("No Data fount");
    return;
  }

  const item = items[0];
  item.title = title;
  item.author = author;
  item.content = content;

  const index = lst.findIndex((x) => x.id === id);
  lst[index] = item;

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem("blogs", jsonBlog);

  successMessage("Updating Success");
}

function deleteBlog(id) {
let result = confirm("are you sure want to delete?");
if(!result) return

  let lst = getBlogs();

  const items = lst.filter((x) => x.id === id);
  if (items.length == 0) {
    console.log("No Data Fount");
    return;
  }

  lst = lst.filter((x) => x.id !== id);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);

  successMessage("Delete SuccessFull!");
  getBlogTable();
}

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}

function getBlogs() {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);

  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

  return lst;
}

$("#btnSave").click(function () {
  const title = $("#txtTitle").val();
  const author = $("#txtAuthor").val();
  const content = $("#txtContent").val();

  if (blogId === null) {
    createBlog(title, author, content);
  } else {
    updateBlog(blogId, title, author, content);
    blogId = null;
  }

  getBlogTable();
});

function successMessage(message) {
  alert(message);
}

function errorMessage(message) {
  alert(message);
}

function clearControls() {
  $("#txtTitle").val("");
  $("#txtAuthor").val("");
  $("#txtContent").val("");
  $("#txtTitle").focus();
}

function getBlogTable() {
  const lst = getBlogs();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    const htmlRow = `
    <tr>
    
    <td>${++count}</td>
    <td>${item.title}</td>
    <td>${item.author}</td>
    <td>${item.content}</td>
    <td>
        <button type="button" class= "btn btn-warning" id="btnSave" onclick = "editBlog('${
          item.id
        }')">Edit</button>
        <button type="button" class= "btn btn-danger" id="btnSave" onclick = "deleteBlog('${
          item.id
        }')">Delete</button>
    </td>
  </tr>
  `;
    htmlRows += htmlRow;
  });

  $("tbody").html(htmlRows);
}
