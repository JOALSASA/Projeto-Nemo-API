**Equipe do Projeto: José Alessandro Santos Santana, Kamille Gomes Bezerra, Hugo Henrique de Santana Fontes, Vitor Gabriel Silva Nascimento**

# Ambiente Encontrado e Ambiente Proposto:

Um professor do curso de Sistemas de Informação do Instituto Federal de Sergipe - Campus Lagarto (IFS) decidiu adotar o aquarismo como novo hobby. Entretanto, este professor possui uma rotina lotada de outras tarefas e teme não ter tempo suficiente para cuidar corretamente dos seus peixinhos.

A rotina de um aquarista exige tarefas diárias para garantir a saúde e o bem-estar dos animais, por exemplo, alimentá-los com a quantidade adequada de comida; verificar a temperatura da água para garantir que esteja dentro da faixa ideal; verificar a qualidade da água medindo os níveis de pH e fazer mudanças parciais de água se necessário; verificar os filtros e fazer a manutenção necessária; verificar a iluminação e fazer ajustes se necessário; dentre outras atividades que podem demandar ainda mais tempo e atenção do criador.

Diante do ambiente encontrado, foi proposta a criação de um sistema web que possibilite ao aquarista uma interação remota com um ou mais aquários. O sistema irá permitir uma visualização dos níveis de pH e temperatura da água, disparar comandos remotos para disponibilizar alimento; disparar comandos remotos para ativar ou desativar a iluminação; gerenciar rotinas de manutenção e limpeza do aquário.

# Hardware utilizados:

- Wemos D1 ESP8266

# Softwares utilizados:

- [Vscode](https://code.visualstudio.com/)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [Git](https://git-scm.com/)
- [Github](https://github.com/)

# Requisitos Funcionais:

### [RF001] Manter novo aquário

Possibilitar que o usuário adicione, edite, remova ou visualize aquários na sua conta.

- **Premissas:**

  O usuário está autenticado no sistema.  
  Ter um microcontrolador cadastrado na rede com o software instalado.

- **Descrição**  
  Assim que o usuário preencher todas as informações e clicar para adicionar um novo aquário o software irá gerar um ID único para esse aquário e mostrar ao usuário.

  O usuário deverá acessar o microcontrolador via navegador utilizando seu IP padrão, e inserir o ID gerado para o aquário.

  O microcontrolador irá fazer uma conexão com a API passando o ID do aquário no endereço.

  Ao final exibir o resultado da conexão.

  O monitoramento dos parâmetros cadastrados será feito com base no nível base informado.

- **Campos:**
  Parâmetro apelido do aquário

  Parâmetros Comprimento, largura e altura

  Parâmetro nível de água

  Parâmetro nível de pH

  Parâmetro nível de temperatura

- **Técnico(s):** Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

### [RF002] Disponibilziar endpoint para ligar/desligar bomba d'água

Permitir que o cliente consuma o serviço de ligar ou desligar a bomba d'água através de um endpoint

- **Premissas:**  
  O cliente está autenticado no sistema.

- **Descrição**  
  O endpoint ficará disponível para que o cliente possa consumir o serviço de gerência da bomba d'água do áquario.

  O Usuário poderá ligar ou desligar a bomba d'água pressionando um botão que deve estar dentro dos menus do aquário escolhido, este botão estará vinculado ao endpoint deste serviço.

  Ao clicar no botão o endpoint irá enviar ao cliente o valor true ou false para ligar ou desligar a bomba d'água.

- **Campos:**  
   Botão Ligar/Desligar bomba d'água

- **Técnico(s):** Técnico(s): Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

### [RF003] Disponibilizar endpoint para ligar/desligar a iluminação do aquário

Permitir que o cliente consuma o serviço de ligar ou desligar a iluminação através de um endpoint

- **Premissas:**  
  O usuário deve estar autenticado no sistema.

- **Descrição**  
  O endpoint ficará disponível para que o cliente possa consumir o serviço de gerência da iluminação do áquario.

  O Usuário poderá ligar ou desligar a iluminação do aquário pressionando um botão que deve estar dentro dos menus do aquário escolhido, este botão estará vinculado ao endpoint deste serviço.

  Ao clicar no botão o endpoint irá enviar ao cliente o valor true ou false para ligar ou desligar a iluminação do aquário.

- **Campos:**
  Botão Ligar/Deligar iluminação

- **Técnico(s):** Técnico(s): Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

### [RF004] Disponibilizar endpoint para ligar/desligar alimentador

Permitir que o cliente consuma o serviço de ligar ou desligar o alimentador através de um endpoint

- **Premissas:**  
  O usuário deve estar autenticado no sistema.

- **Descrição**  
  O endpoint ficará disponível para que o cliente possa consumir o serviço de gerência do alimentador do áquario.

  O Usuário poderá ligar ou desligar o dispositivo que dispara alimento no aquário pressionando um botão que deve estar dentro dos menus do aquário escolhido, este botão estará vinculado ao endpoint deste serviço.

  Ao clicar no botão o endpoint irá enviar ao cliente o valor true ou false para ligar ou desligar o alimentador.

- **Campos:**
  Botão Ligar/Deligar alimentador

- **Técnico(s):** Técnico(s): Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

### [RF005] Disponibilizar endpoint para ligar/desligar controlador de pH

Permitir que o cliente consuma o serviço de ligar ou desligar o controlador de pH através de um endpoint

- **Premissas:**  
  O usuário deve estar autenticado no sistema.

- **Descrição**  
  O endpoint ficará disponível para que o cliente possa consumir o serviço de gerência do controlador de pH do áquario.

  O Usuário poderá ligar ou desligar o controlador de pH pressionando um botão que deve estar dentro dos menus do aquário escolhido, este botão estará vinculado ao endpoint deste serviço.

  Ao clicar no botão o endpoint irá enviar ao cliente o valor true ou false para ligar ou desligar o controlador de pH.

- **Campos:**
  Botão Ligar/Deligar controlador de pH

- **Técnico(s):** Técnico(s): Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

### [RF006] Disponibilizar endpoint para ligar/desligar termostato

Permitir que o cliente consuma o serviço de ligar ou desligar o termostato através de um endpoint

- **Premissas:**  
  O usuário deve estar autenticado no sistema.

- **Descrição**  
  O endpoint ficará disponível para que o cliente possa consumir o serviço de gerência do termostato do áquario.

  O Usuário poderá ligar ou desligar o termostato pressionando um botão que deve estar dentro dos menus do aquário escolhido, este botão estará vinculado ao endpoint deste serviço.

  Ao clicar no botão o endpoint irá enviar ao cliente o valor true ou false para ligar ou desligar o termostato.

- **Campos:**
  Botão Ligar/Deligar termostato

- **Técnico(s):** Técnico(s): Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

### [RF007] Manter alertas

Possibilitar que o usuário adicione, edite, remova ou visualize alertas para os parâmetros base dos aquários na sua conta.

- **Premissas:**

  O usuário está autenticado no sistema.  
  Ter um microcontrolador cadastrado na rede com o software instalado.

- **Descrição**  
  Assim que o usuário preencher todas as informações e clicar para adicionar um novo alerta, este deverá ficar disponível na sessão de alertas do sistema.

  Um alerta será disparado após o sistema identificar que o parâmetro monitorado atingiu o limite estabelecido. Este alerta irá disparar uma notificação ao usuário.

- **Campos:**
  Aquário

  Parâmetro

  Tipo de alerta (Ex.: maior que o limite)

  Valor limite

  Status (Ex.: Ativo)

- **Técnico(s):** Alessandro, Gabriel, Hugo, Kamille e Vitor.
- **Data:** 03/04/2023
- **Comunicação:** Sala de Aula (Presencial)

#### Necessário revisar

### [----] Customizar alertas

Permitir que o usuário customize alertas para o aquário.

Premissas:

O usuário está autenticado no sistema.

Ter um aquário cadastrado com o módulo a ser utilizado.

Campos:

Módulo

Tipo

Se a temperatura passar do nível normal

Comida

limpeza

Técnico: Alessandro, Gabriel, Hugo, Kamille e Vitor.

Data: 30/03/2023

Comunicação: Sala de Aula

### [----] Gráfico para controle dos níveis por hora

Pegar as informações de hora em hora por uma média e mostrar num gráfico de linha as oscilações durante um tempo

Técnico: Alessandro, Gabriel, Hugo, Kamille e Vitor.

Data: 30/03/2023

Comunicação: Sala de Aula