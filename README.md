# TINY Language Compiler



This repository contains the implementation of a custom compiler for the TINY programming language. The project is being built in phases, starting with the Lexical Analyzer (Scanner).



## Milestone 1: Lexical Analyzer (Scanner)

The scanner reads raw TINY source code, strips out formatting and comments, and categorizes the remaining characters into a stream of valid Tokens. 



### Features

* **Token Classification:** Accurately identifies reserved keywords, identifiers, constant numbers, string literals, and operators.

* **Comment & Whitespace Handling:** Completely ignores multi-line C-style comments (`/* ... */`) and standard whitespace before processing tokens.

* **Error Detection:** Catches illegal or unrecognized characters and isolates them in a dedicated Error List without crashing the engine.

* **UI Integration:** Built with a Windows Forms frontend that dynamically populates a Lexeme-to-Token DataGridView.



### The TINY Language Specification

The TINY language consists of 30 distinct grammar and syntax rules. The complete official language description can be found in the attached document: `Tiny PL _ Language description_.docx`.



**Supported Lexical Tokens:**

* **Keywords:** `int`, `float`, `string`, `read`, `write`, `repeat`, `until`, `if`, `elseif`, `else`, `then`, `return`, `endl`, `end`, `main`

* **Operators:** `+`, `-`, `*`, `/`, `:=`, `<`, `>`, `=`, `<>`, `&&`, `||`

* **Punctuation:** `;`, `,`, `(`, `)`, `{`, `}`

* **Dynamic Types:** `Identifier`, `Constant`, `StringLiteral`



## How to Run

1. Clone this repository.

2. Open the solution in Visual Studio.

3. Build and run the Windows Forms application.

4. Type or paste valid TINY code into the input text box.

5. Click **Compile** to generate the Token Stream and verify syntax errors.

