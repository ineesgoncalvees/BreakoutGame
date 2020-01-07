# BreakoutGame

## Projeto 2 - Linguagens de Programação 2

Projeto realizado por:

* [Diana Nóia](https://github.com/DianaNoia): a21703004
* [Inês Gonçalves](https://github.com/ineesgoncalvees): a21702076

### Repositório

O projeto pode ser encontrado neste
[repositório](https://github.com/ineesgoncalvees/BreakoutGame).

## Repartição de Tarefas

* Diana Nóia
  * UML
  * Relatório
  * Programação:
    * Classe Program
    * Classe Menu:
      * Criar menu inicial;
      * Arranjar menu;
      * Adicionar cor aos bricks, ajustá-los ao ecrã;
    * Classe Paddle:
      * Adicionar a paddle;
    * Classe Breakout:
      * Adicionar game over;
    * Classe GameManager:
      * Adicionar Game Loop inicial;

* Inês Gonçalves
  * Programação:
    * Classe Program
    * Classe Brick
      * Adicionar informação para criar os bricks;
    * Classe Menu
      * Imprimir os bricks
      * Imprimir a paddle
    * Classe Paddle
      * Adicionar movimento da paddle
    * Classe Ball:
      * Criar bola;
      * Adicionar movimento da bola;
      * Adicionar colisões da bola com as paredes;
      * Adicionar colisões da bola com a paddle;
      * Adicionar colisões da bola com os bricks;
      * Criar sistema de pontos, aos quais adiciona pontos após a colisão com os
  bricks
    * Classe Breakout
    * Classe GameManager

## Descrição do problema

O desafio para este projeto era implementar um jogo em C#, usando design
patterns principais na criação de jogos, bem como tendo em conta os diferentes
principios de design de classes, como por exemplo os principios SOLID.

A nossa escolha foi implementar o Breakout.

## Arquitetura da solução

iterator pq usamos foreach 


descrição da solução, com breve explicação de como o programa foi organizado,
indicação dos design patterns utilizados e a razão do seu uso, bem como dos
algoritmos implementados (e.g., para deteção de colisões, cálculo de ângulos e
trajetórias, etc).

Um diagrama UML de classes simples (i.e., sem indicação dos membros da classe)
descrevendo a estrutura de classes.

Um fluxograma mostrando o funcionamento do programa.

![FLUXOGRAMA](fluxograma.svg);

UML de classes simples que descreve a estrutura das classes.

![UML](uml.svg);

## Referências

* Whitaker, R. B. (2016). The C# Player's Guide (3rd Edition). Starbound Software.