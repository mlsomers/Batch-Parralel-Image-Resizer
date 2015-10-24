# Batch-Parralel-Image-Resizer
An image resizing application using parrallel processing

This application started out as an example implementation of a terformance tip featured in RedGate's free e-book ’52 Tips & Tricks to Boost .NET Performance’ (http://rd.gt/1LHiIBX).

In my blogpost at http://www.infotopie.nl/blog/perf/bottlenecks I elaborate on this technique with a little more detail.

This initial alpha version of the app is working on my machine, has only partially been tested, and is by no means "production ready".

I am playing with the idea to use the app as a basis for uploading images to a Synology Diskstation. The requirements will change in that case, multiple thumbnail sizes will need to be generated, and will need to be uploaded using the undocumented PHP API instead of simply stored to disk.

Disclaimer for potential future employers: When I write code in my scarce free time I tend to cut corners and don't pay too much attention to coding standards. This is not SOLID, nither is it "clean". Please don't judge my ability to write code on this project. Thanks.

The icons used in this application are from FamFamFam (http://www.famfamfam.com/lab/icons/silk/).

This software is based in part on the work of the Independent JPEG Group.