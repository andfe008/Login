import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-triki-game',
  templateUrl: './triki-game.component.html',
  styleUrls: ['./triki-game.component.scss']
})
export class TrikiGameComponent {

  turn: number = 0;
  turnOf: string = "";
  button: any = [];
  Rules: any = [];
  ReloadTurn: boolean = false;
  Iswinner: boolean = false;
  MarkWinner: string = "";
  Flag: boolean[] = [];

  constructor() {
    this.turn = 1;
    this.turnOf = "X";
    this.InitializeButtons();
    this.InitializeRules();
  }

  InitializeFlags() {
    this.Flag = [false, false, false]
  }

  InitializeRules() {
    this.Rules = [
      [1, 2, 3],
      [4, 5, 6],
      [7, 8, 9],
      [1, 4, 7],
      [2, 5, 8],
      [3, 6, 9],
      [1, 5, 9],
      [3, 5, 7]]
  }

  InitializeButtons() {
    this.button = [
      { btn1: "" },
      { btn2: "" },
      { btn3: "" },
      { btn4: "" },
      { btn5: "" },
      { btn6: "" },
      { btn7: "" },
      { btn8: "" },
      { btn9: "" },
    ]
  }

  AddMark(button: string) {
    if (this.ValidateTurn() && this.ValidateMark(button) && !this.Iswinner) {
      if (this.turn % 2 == 0) {
        this.turnOf = "X";
        this.button[button] = "O";
      } else {
        this.turnOf = "O";
        this.button[button] = "X";
      }
      if (this.turn == 9) {
        this.turnOf = "Se acabaron los turnos";
      }
      this.button[button];
      this.Validatewinner();
      this.turn++;
    }
  }

  ValidateMark(button: string) {
    debugger
    if (this.button[button] != undefined) {
      return false;
    }
    return true;
  }

  ValidateTurn(): boolean {
    if (this.turn > 8) {
      this.turnOf = "Se acabaron los turnos";
      if (this.turn == 9) {
        return true;
      } else {
        return false;
      }
    }
    return true;
  }

  Validatewinner() {
    debugger
    let marks: string[] = ["X", "O"];
    marks.forEach(mark => {
      for (let i = 0; i < this.Rules.length; i++) {
        let validator: boolean = true;
        this.InitializeFlags();
        for (let j = 0; j < this.Rules[i].length; j++) {
          if (this.button["btn" + this.Rules[i][j]] != undefined
            && this.button["btn" + this.Rules[i][j]] == mark) {
            this.Flag[j] = true;
          }
        }
        this.Flag.forEach(Flags => {
          if (!Flags) {
            validator = false;
          }
        });
        if (validator) {
          this.MarkWinner = `${mark == "X" ? "La" : "El"} ${mark} Gana`;
          this.Iswinner = true;
        }
      }
    });
  }

  Restart() {
    this.turn = 1;
    this.turnOf = "X";
    this.InitializeButtons();
  }
}
