# Presentations

These presentations are written in markdown and can be published as pdf, for example with pandoc:

```
docker run --rm --volume "`pwd`:/data" --user `id -u`:`id -g` pandoc/latex -t beamer -V theme:Boadilla --shift-heading-level-by=-1 software-engineering.md -o software-engineering.pdf
```
