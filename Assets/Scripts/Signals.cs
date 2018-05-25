using System;
using strange.extensions.signal.impl;

public class StartSignal : Signal { }

public class StartSpin : Signal { }
public class StopSpin : Signal { }

public class UpdateBetSignal : Signal { }
public class BetSignal : Signal<float> { }

public class Spin_Button_Clicked_Signal : Signal { }

public class Bet_More_Round_Signal : Signal { }
public class Start_Force_Stop_Signal : Signal { }

public class Update_Game_Result_Signal : Signal { }
public class CHANGE_SCORE_Signal : Signal<float> { }
public class CHANGE_CREDIT_Signal : Signal<float> { }
public class Game_Update_Done_Signal : Signal { }

//public class SpinSignal : Signal { }