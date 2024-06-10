const tblBlog = "blogs";
let blogId = null;

getBlogTable();
// testConfirmMessage();
testConfirmMessage2();

// createBlog();
// updateBlog("dcec69f8-ec35-4828-aabe-b607d9f7f777","adfadfadfa","afasadsfasfq34frdsf","afasdfew");
// deleteBlog("8a3b9dda-d63b-4051-b95f-e370d3062e3a");

function testConfirmMessage() {
  let confirmMessage = new Promise(function (success, error) {
    // "Producing Code" (May take some time)
    const result = confirm("Are you sure want to delete?");
    if (result) {
      success(); // when successful
    } else {
      error(); // when error
    }
  });

  confirmMessage.then(
    function (value) {
      /* code if successful */
      successMessage("Success");
    },
    function (error) {
      /* code if some error */
      errorMessage("Error");
    }
  );
}

function testConfirmMessage2() {
  let confirmMessage = new Promise(function (success, error) {
    // "Producing Code" (May take some time)

    Swal.fire({
      title: "Confirm",
      text: "Are you sure want to delete?",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Yes",
    }).then((result) => {
      if (result.isConfirmed) {
        success(); // when successful
      } else {
        error(); // when error
      }
    });
  });

  // "Consuming Code" (Must wait for a fulfilled Promise)
  confirmMessage.then(
    function (value) {
      /* code if successful */
      successMessage("Success");
    },
    function (error) {
      /* code if some error */
      errorMessage("Error");
    }
  );
}

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

// function deleteBlog1(id) {
//   let result = confirm("are you sure want to delete?");
//   if (!result) return;

//   let lst = getBlogs();

//   const items = lst.filter((x) => x.id === id);
//   if (items.length == 0) {
//     console.log("No Data Fount");
//     return;
//   }

//   lst = lst.filter((x) => x.id !== id);
//   const jsonBlog = JSON.stringify(lst);
//   localStorage.setItem(tblBlog, jsonBlog);

//   successMessage("Delete SuccessFull!");
//   getBlogTable();
// }

function deleteBlog(id) {

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

function confirmDeleteBox(id) {
  const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
      confirmButton: "btn btn-success",
      cancelButton: "btn btn-danger",
    },
    buttonsStyling: false,
  });
  swalWithBootstrapButtons
    .fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Yes, delete it!",
      cancelButtonText: "No, cancel!",
      reverseButtons: true,
    })
    .then((result) => {
      if (result.isConfirmed) {
        let lst = getBlogs();

        const items = lst.filter((x) => x.id === id);
        if (items.length == 0) {
          console.log("No Data Fount");
          return;
        }

        lst = lst.filter((x) => x.id !== id);
        const jsonBlog = JSON.stringify(lst);
        localStorage.setItem(tblBlog, jsonBlog);

        swalWithBootstrapButtons.fire({
          title: "Deleted!",
          text: "Your file has been deleted.",
          icon: "success",
        });
        getBlogTable();
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        swalWithBootstrapButtons.fire({
          title: "Cancelled",
          text: "Your imaginary file is safe :)",
          icon: "error",
        });
      }
    });
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
        <button type="button" class= "btn btn-danger" id="btnSave" onclick = "confirmDeleteBox('${
          item.id
        }')">Delete</button>
    </td>
  </tr>
  `;
    htmlRows += htmlRow;
  });

  $("tbody").html(htmlRows);
}
