using System;
using strange.extensions.signal.impl;

public class StartSignal : Signal { }

public class StartSpin : Signal { }
public class StopSpin : Signal { }

public class CHANGE_SCORE_Signal : Signal<float> { }
public class CHANGE_CREDIT_Signal : Signal<float> { }

public class UpdateBetSignal : Signal<float> { }
public class BetSignal : Signal<float> { }

public class SpinSignal : Signal { }

