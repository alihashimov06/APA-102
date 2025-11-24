//1.Verilmis arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek. 
// let arr = [2, 5, 7, 9, 5, 7, 7, 2, 2];

// let numbers = {};

// for (let i = 0; i < arr.length; i++) {
//     let num = arr[i];

//     if (numbers[num] === undefined) {
//         numbers[num] = 1;
//     } else {
//         numbers[num]++;
//     }
// }

// let repeatedNumbersCount = 0;

// for (let key in numbers) {
//     if (numbers[key] > 1) {
//         repeatedNumbersCount++;   
//     }
// }

// let newArr = [];
// let index = 0;

// for (let key in numbers) {
//     newArr[index] = Number(key);
//     index++;
// }

// console.log("Təkrarlanan rəqəmlərin sayı:", repeatedNumbersCount);
// console.log("Yeni array:", newArr);

//----------------------------------------------------

//2.Verilmis sozun polindrom olub olmadığını yoxlayan alqoritm yazmaq.

// let word = "level";
// let isPalindrome = true;

// let start = 0;
// let end = word.length - 1;

// while (start < end) {
//     if (word[start] !== word[end]) {
//         isPalindrome = false;
//         break;
//     }
//     start++;
//     end--;
// }

// if (isPalindrome) {
//     console.log("Polindromdur");
// } else {
//     console.log("Polindrom deyil");
// }

//--------------------------------------------------------

//3.Girilen ededin verilmis arreyde nece elementden kicik oldugunu yazan alqoritim.

// let arr = [3, 10, 5, 2, 8];
// let x = 6;  
// let count = 0;

// for (let i = 0; i < arr.length; i++) {
//     if (arr[i] < x) {
//         count++;
//     }
// }

// console.log(x, "reqeminden kiçik reqemlerinin sayı:", count);

//4.Daxil edilen ededin Aboundant ve ya Deficient oldugunu yoxlayan algorithm.
// (Abundant ədəd öz müsbət bolenlerinin(ozunden basqa)
//  cəmi özündən böyük olan müsbət tam ədədlərə deyilir.
// Eks halda Deficient eded olur. 12-Aboundant, 13- Deficient)


// let n = 12; 
// let sum = 0;

// for (let i = 1; i < n; i++) {  
//     if (n % i === 0) {         
//         sum += i;
//     }
// }

// if (sum > n) {
//     console.log(n + " Abundant reqemdir");
// } else {
//     console.log(n + " Deficient reqemdir");
// }

//5.Array-in bütün elementlərini kvadrata yüksəldib yeni array qaytaran funksiya yazın.

//  function squareArray(arr) {
//      let result = [];       
//      let index = 0;         

//      for (let i = 0; i < arr.length; i++) {
//          result[index] = arr[i] * arr[i];
//          index++;
//      }

//      return result;
//  }

//  let numbers = [1, 2, 3, 4, 5];
//  let squaredNumbers = squareArray(numbers);

//  console.log("Original arry:", numbers);
//  console.log("Deyismis arry:", squaredNumbers);
