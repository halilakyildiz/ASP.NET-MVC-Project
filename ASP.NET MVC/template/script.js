
left_arrow = document.getElementById("left-arr");
right_arrow = document.getElementById("right-arr");
button = document.getElementById("hamburger-btn");
let count = document.getElementById("pr-count").value;
let sayac=0;
let index=0;
function products_left(){
    var w = window.innerWidth;
    if(w>1200){
        if(index!=0)   
        index++;
        gsap.to(".products-slider",.8,{x: `${index*33.33}%`});
    }
    else if(w>600){
        if(index!=0)   
        index++;
        gsap.to(".products-slider",.8,{x: `${index*50}%`});
    }
    else{
        if(index!=0)   
        index++;
        gsap.to(".products-slider",.8,{x: `${index*100}%`});
    }
}
function products_right(){
    var w = window.innerWidth;
    if(w>1200){
        if(index>-(count-3))
        index--;
        gsap.to(".products-slider",.8,{x: `${index*33.33}%`});
    }
    else if(w>600){
        if(index>-(count-3)-1)
        index--;
        gsap.to(".products-slider",.8,{x: `${index*50}%`});
    }
    else{
        if(index>-(count-3)-2)
        index--;
        gsap.to(".products-slider",.8,{x: `${index*100}%`});
    }
}
function kaydir(){
    gsap.to(".index-slider",.8,{x: `${-sayac*100}%`});
    sayac++;
    if(sayac>4)
        sayac=0;
}
let flag=0;
function dropdown_slide(){
    if(flag==0){
        gsap.to(".dropdown-menu",.8,{x: `0%`});
        flag=1;
    }
    else{
        gsap.to(".dropdown-menu",.8,{x: `101%`});
        flag=0;
    }
    
}
setInterval(kaydir, 6000);

left_arrow.addEventListener("click", products_left);
right_arrow.addEventListener("click", products_right);
button.addEventListener("click", dropdown_slide);
