const input1 = document.querySelectorAll(".input-box")[0];
const input2 = document.querySelectorAll(".input-box")[1];
const result = document.querySelector(".bottom-input");

result.disabled = true;

const buttons = document.querySelectorAll(".buttons button");

function clearInputs() {
  input1.value = "";
  input2.value = "";
  result.value = "";
}

function alertAndClear(msg) {
  alert(msg);
  clearInputs();
}

buttons.forEach((btn) => {
  btn.addEventListener("click", function () {

    if (btn.textContent === "Clear") {
      clearInputs();
      result.value = "";
      return;
    }

    if (input1.value === "" || input2.value === "") {
      alertAndClear("Bu inputlardan heç birini boş buraxmaq olmaz!");
      return;
    }

    const val1 = Number(input1.value);
    const val2 = Number(input2.value);

    switch (btn.textContent) {
      case "Plus":
        result.value = val1 + val2;
        break;

      case "Minus":
        result.value = val1 - val2;
        break;

      case "Mult":
        result.value = val1 * val2;
        break;

      case "Devide":
        if (val2 === 0) {
          alertAndClear("0-a bölmək olmaz!");
          return;
        }
        result.value = val1 / val2;
        break;
    }

    
    clearInputs();
  });
});
