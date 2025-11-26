const app = document.createElement("div");
app.id = "app";
document.body.appendChild(app);


const card = document.createElement("div");
card.style.width = "350px";
card.style.borderRadius = "12px";
card.style.overflow = "hidden";
card.style.boxShadow = "0 4px 15px rgba(0,0,0,0.15)";
card.style.background = "#fff";
card.style.fontFamily = "Arial";
card.style.margin = "20px auto";

const cardImg = document.createElement("div");
cardImg.style.position = "relative";

const img = document.createElement("img");
img.src = "./assets/image/home.jpg";
img.style.width = "100%";
img.style.height = "200px";
img.style.objectFit = "cover";

const fav = document.createElement("span");
fav.textContent = "♡";
fav.style.position = "absolute";
fav.style.top = "12px";
fav.style.right = "12px";
fav.style.background = "white";
fav.style.padding = "6px 10px";
fav.style.borderRadius = "50%";
fav.style.fontSize = "18px";
fav.style.cursor = "pointer";

cardImg.appendChild(img);
cardImg.appendChild(fav);


const body = document.createElement("div");
body.style.padding = "18px";

const type = document.createElement("p");
type.textContent = "DETACHED HOUSE • 5Y OLD";
type.style.color = "#6c757d";
type.style.fontSize = "13px";
type.style.fontWeight = "bold";
type.style.letterSpacing = "1px";

const price = document.createElement("h2");
price.textContent = "$750,000";
price.style.margin = "5px 0";
price.style.fontSize = "28px";

const address = document.createElement("p");
address.textContent = "742 Evergreen Terrace";
address.style.marginBottom = "15px";
address.style.color = "#555";

const info = document.createElement("div");
info.style.display = "flex";
info.style.gap = "20px";
info.style.marginBottom = "20px";

function createInfoItem(icon, text) {
  const item = document.createElement("div");
  item.style.display = "flex";
  item.style.alignItems = "center";
  item.style.gap = "6px";

  const img = document.createElement("img");
  img.src = icon;
  img.style.width = "22px";
  img.style.opacity = "0.75";

  const span = document.createElement("span");
  span.innerHTML = text;

  item.appendChild(img);
  item.appendChild(span);
  return item;
}

info.appendChild(
  createInfoItem(
    "https://cdn-icons-png.flaticon.com/512/69/69524.png",
    "<b>3</b> Bedrooms"
  )
);

info.appendChild(
  createInfoItem(
    "https://cdn-icons-png.flaticon.com/512/833/833539.png",
    "<b>2</b> Bathrooms"
  )
);

const realtor = document.createElement("div");
realtor.style.display = "flex";
realtor.style.alignItems = "center";
realtor.style.borderTop = "1px solid #eee";
realtor.style.paddingTop = "15px";

const avatar = document.createElement("img");
avatar.src = "./assets/image/foto_girl.jpg";
avatar.style.width = "48px";
avatar.style.height = "48px";
avatar.style.borderRadius = "50%";
avatar.style.marginRight = "12px";

const realtorInfo = document.createElement("div");

const name = document.createElement("p");
name.textContent = "Tiffany Heffner";
name.style.fontWeight = "bold";

const phone = document.createElement("p");
phone.textContent = "(555) 555-4321";
phone.style.color = "#666";
phone.style.fontSize = "14px";

realtorInfo.appendChild(name);
realtorInfo.appendChild(phone);
realtor.appendChild(avatar);
realtor.appendChild(realtorInfo);

body.appendChild(type);
body.appendChild(price);
body.appendChild(address);
body.appendChild(info);
body.appendChild(realtor);

card.appendChild(cardImg);
card.appendChild(body);

app.appendChild(card);
