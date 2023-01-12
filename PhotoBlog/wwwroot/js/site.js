// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

dayjs.extend(window.dayjs_plugin_relativeTime)

/*1- Reach every element that has data-post-time attribute*/
/*2- Take the value that is in the data-post-time attribute */
/*3- dayjs().to(dayjs('2023-01-12T16:43:10')) Put time inside of this and take the output  */
/*4-  Assign the attribute to the element that ve reached in 1st step */


$("[data-post-time]").each(function () {
    let isoTime = $(this).data("post-time");
    let relativeTime = dayjs().to(dayjs(isoTime));
    $(this).text(relativeTime);
});