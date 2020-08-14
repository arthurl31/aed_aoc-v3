# AED_AOC-V3
#### Este trabalho foi desenvolvido por [Arthur Luiz](https://github.com/arthurl31) e [Gabrielle Rosanne](https://github.com/GabrielleRSAlbergaria)

Este trabalho foi executado de maneira interdisciplinar no segundo semestre do cuso de graduação de Sistemas de Informação, unindo as disciplinas de AED (Algorítmos e Estruturas de Dados) e AOC (Arquitetura e Organização de Computadores.

## Sobre o simulador
O simulador consiste em simular o funcionamento da troca de blocos entre uma memória principal e uma
memória cache, associativa por conjunto de N posições, durante a execução do programa.

**Funcionamento do Simulador:**

    1) O simulador deverá receber como entrada os seguintes dados:
        a - O tamanho da memória principal em bytes.
        b - O tamanho do bloco em bytes.
        c - A quantidade de linhas da memória cache.
        d - O valor de N.
        e - O algoritmo de substituição que será utilizado pela memória cache (LRU, LFU, FIFO).
        f - A sequência de números de blocos que serão acessados pelo processador durante a
        execução do programa.

    2) A memória cache deverá estar inicialmente vazia.
    
    3) O simulador disponibiliza um botão para a carga de bloco passo a passo, a partir da
       memória principal, para a memória cache.
       
    4) O simulador contem, uma interface para:
   
        a - Entrada dos dados listados no item 1.
        b - Visualização dos blocos na memória principal.
        c - Visualização dos blocos carregados na memória cache, passo a passo.
        d - Visualização da troca de blocos entre as memórias, utilizando o algoritmo de substituição
           previamente selecionado.
           
       
