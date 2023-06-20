// Unity Arduino 연동하기

void setup() {
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);
}

void loop() {
  if (Serial.available()) {
    String data = Serial.readStringUntil('\n'); // 개행 문자를 구분자로 문자열 입력 받음
    data.trim(); // 문자열 앞뒤 공백 제거

    if (data == "C") {
      digitalWrite(LED_BUILTIN, HIGH); // LED를 켬
    } 
    else if (data == "D") {
      digitalWrite(LED_BUILTIN, LOW); // LED를 끔
    }
  }
}



/*
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available())
  {

    int data = Serial.read();
    if (data == '1')
      {
        digitalWrite(LED_BUILTIN, HIGH);
      }
    else if (data == '2')
      {
        digitalWrite(LED_BUILTIN, LOW);
      }
  }
}
*/

/*
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available())
  {
    String data = Serial.readString(); 
    float floatValue = data.toFloat();  // 문자열을 소수로 변환
    //int data = Serial.read();
    
    if (floatValue == 0.02f)
      {
        digitalWrite(LED_BUILTIN, HIGH);
      }
    else if (floatValue == 2.0f)
      {
        digitalWrite(LED_BUILTIN, LOW);
      }
  }
  
}
*/