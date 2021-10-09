#include "Wire.h"


//===== Firmware Máquina Automatização Difratômetro =======
//=============== Guilherme Parreira Gomes ================
//=============== Centro Universitário FEI ================
//====================== 2020/2021 ========================

//Email: guigoparreira10@gmail.com


/*

* Firmware do microcontrolador da máquina / automatização do
* difratometro de raios-X - laboratório LERI (Sala D015).

    Drivers:
    https://github.com/stm32duino/BoardManagerFiles/raw/master/package_stmicroelectronics_index.json

  - Microcontrolador: STM32F103C8
  - Conversor USB-SERIAL: FTDI 232

* As letras no começo do nome de cada arquivo representa a ordem
* que eles serão compilados. 
* Desta maneira, variáveis e funções em arquivos posteriores não poderão ser acessadas em arquivos
* anteriores


* Este arquivo é o principal da solução, ou seja, é o que deve ser aberto para
* editar o código.  Todas as inclusões de bibliotecas devem
* ser feitas aqui.

* Arquivos:
* a_tools - > Ferramentas, classes e funções úteis
* b_config -> Configurações gerais
* c_vars -> Variáveis Globais
* d_sensors -> Sensores
* e_motors -> Motores / Movimentos
* f_Serial -> Comunicação Serial com o computador / Comandos entre máquina/painel
* z_main -> Arquivo principal, contém setup e loop



//obs -> Configuração timer (micros() - lastTime >= delay) evita problemas de reset da func micros()



*/
