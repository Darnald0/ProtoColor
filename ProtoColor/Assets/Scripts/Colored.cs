using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colored : MonoBehaviour {
    public enum ColoredState { COLORLESS, WATER, EARTH, WIND, FIRE, ICE, STEAM };
    [SerializeField] private ColoredState _state => State;
    public ColoredState State;
    private SpriteRenderer spriteRenderer;
    public Movement move;
    private void Start() {
        move = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor(this);
    }
    public static void ChangeState(Colored target, ColoredState newColor) {
        target.State = newColor;
        ChangeColor(target);
    }
    public static void NewState(Colored target, ColoredState newColor) {
        switch (target.State) {
            case ColoredState.WATER:
                switch (newColor) {
                    case ColoredState.EARTH:
                        target.State = ColoredState.EARTH;
                        break;
                    case ColoredState.WIND:
                        target.State = ColoredState.ICE;
                        break;
                    case ColoredState.FIRE:
                        target.State = ColoredState.STEAM;
                        break;
                    case ColoredState.ICE:
                        target.State = ColoredState.ICE;
                        break;
                    default:
                        break;
                }
                break;
            case ColoredState.WIND:
                switch (newColor) {
                    case ColoredState.WATER:
                        target.State = ColoredState.ICE;
                        break;
                    case ColoredState.EARTH:
                        target.State = ColoredState.EARTH;
                        break;
                    case ColoredState.FIRE:
                        target.State = ColoredState.FIRE;
                        break;
                    case ColoredState.ICE:
                        target.State = ColoredState.ICE;
                        break;
                    default:
                        break;
                }
                break;
            case ColoredState.FIRE:
                switch (newColor) {
                    case ColoredState.WATER:
                        target.State = ColoredState.STEAM;
                        break;
                    case ColoredState.WIND:
                        target.State = ColoredState.WIND;
                        break;
                    case ColoredState.EARTH:
                        target.State = ColoredState.EARTH;
                        break;
                    case ColoredState.ICE:
                        target.State = ColoredState.WATER;
                        break;
                    default:
                        break;
                }
                break;
            case ColoredState.EARTH:
                switch (newColor) {
                    case ColoredState.WATER:
                        target.State = ColoredState.WATER;
                        break;
                    case ColoredState.WIND:
                        target.State = ColoredState.WIND;
                        break;
                    default:
                        break;
                }
                break;
            case ColoredState.ICE:
                switch (newColor) {
                    case ColoredState.FIRE:
                        target.State = ColoredState.WATER;
                        break;
                    default:
                        break;
                }
                break;
            case ColoredState.COLORLESS:
            default:
                target.State = newColor;
                break;
        }
        ChangeColor(target);
        ChangeBehaviour(target);
    }


    static void ChangeColor(Colored target) {
        switch (target.State) {
            case ColoredState.WATER:
                target.spriteRenderer.color = Color.blue;
                break;
            case ColoredState.WIND:
                target.spriteRenderer.color = Color.green;
                break;
            case ColoredState.FIRE:
                target.spriteRenderer.color = Color.red;
                break;
            case ColoredState.EARTH:
                target.spriteRenderer.color = new Color(88 / 255f, 47/ 255f, 14 / 255f);
                break;
            case ColoredState.ICE:
                target.spriteRenderer.color = new Color(72 / 255f, 202 / 255f, 228 / 255f);
                break;
            case ColoredState.STEAM:
                target.spriteRenderer.color = new Color(3 / 255f, 4 / 255f, 94 / 255f);
                break;
            case ColoredState.COLORLESS:
            default:
                target.spriteRenderer.color = Color.white;
                break;
        }
    }

    static void ChangeBehaviour(Colored target) {
        switch (target.State) {
            case ColoredState.ICE:
                target.move.canMove = false;
                break;
            case ColoredState.STEAM:
                target.move.canMove = false;
                target.StartCoroutine(target.Steamed());
                break;
            case ColoredState.WATER:
                target.move.canMove = true;
                break;
            case ColoredState.EARTH:
                target.move.canMove = true;
                break;
            case ColoredState.WIND:
                target.move.canMove = true;
                break;
            case ColoredState.FIRE:
                target.move.canMove = true;
                break;
            case ColoredState.COLORLESS:
            default:
                target.move.canMove = true;
                break;
        }
    }
    IEnumerator Steamed() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
