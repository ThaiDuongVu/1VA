// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9bccdadc-c018-4cb7-aab3-627c75c19675"",
            ""actions"": [
                {
                    ""name"": ""MoveKeyboard"",
                    ""type"": ""Button"",
                    ""id"": ""b777ffe4-9cf0-4c3d-8459-c5f48caaf3b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveGamepad"",
                    ""type"": ""Value"",
                    ""id"": ""d7eb9592-cc5c-4dc9-8760-99ea0f0d30cc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""3f7f00b8-4d65-4355-8a1c-1894318b8d39"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""acbfc31a-f383-4498-9cf8-f372a71a57ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Strike"",
                    ""type"": ""Button"",
                    ""id"": ""b122f8d6-83d2-4b4e-aac4-d2907dbbaf28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Counter"",
                    ""type"": ""Button"",
                    ""id"": ""98124155-a76e-4678-ad1c-b8b4385c3078"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookToLock"",
                    ""type"": ""Button"",
                    ""id"": ""1f638ecb-f399-4912-83e5-b75dbc8a5ff3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TakeDown"",
                    ""type"": ""Button"",
                    ""id"": ""b61a3cbd-1b5e-4ef6-99f2-dc2100ba190c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f6bdd674-b12d-4768-af42-154d7b8842d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""227b1fa5-b3b2-460d-863e-eb07d9962933"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a48976b-0258-438a-96e7-149fcd29e05a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c44cb501-0da1-42aa-9772-9bb0a5791175"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""185bbc4a-6408-44a9-9cab-c2a5d8a04bbb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""a24d5b8a-4c60-4fa3-b8df-71f586fb5bbe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1569ca0c-bae6-4ce9-bd71-12ec1232be5a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""688fb73a-cbc3-4bb1-8686-e37f3cc07ce9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fe01fc8e-3238-4da8-9bab-8e56746199de"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8c7eaa35-713a-4ee0-b865-119585fd7c0c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""0788fa90-1ab3-46d5-9aee-b86e8e215b97"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveGamepad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""663b6866-94f9-4b50-964b-348e716c662d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cb903227-0157-489c-8f52-9a757d5fdbb7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""55f97400-55fe-4f6f-a352-8ce829236189"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bc22d650-4dfb-47c0-a9a4-c54c4172d275"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""093970a2-bf77-4f9f-b1a0-cffe83627506"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a305c494-cbce-4135-ab41-2399fdf0e1b8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ae09a41-b48e-4830-b0b5-31b5b06c2f72"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Strike"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bb35048-bc67-4788-a344-e09d7a140b68"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Strike"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef1336b5-04c6-4011-9ea3-82e836834604"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Counter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4de5c78c-0b49-4423-b190-9f4e0b83f333"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Counter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""RightStick"",
                    ""id"": ""86bf2e4d-a3ac-4b20-b4ba-125c319d7f53"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e9e0db4-70a9-49fd-9bde-ffb3ad9e2d48"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e7a88b25-b438-46e4-a0c0-42814c0e1a78"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23236941-9250-48a2-a7c1-ea9173ffacaa"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2.5),Invert"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b92f966b-8d10-45df-996d-f3f966215217"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2.5),Invert"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""cb35ad89-a89f-4a9e-afdc-3ffa41f80dd8"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f93a3408-2dd1-4913-94ee-aae4f92de5ac"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b8baceec-18b0-470b-881c-556fe23a53af"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f6b7d2b-9a04-493d-b61e-c81bbae364f0"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1),Scale(factor=0.1)"",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3669a03f-9f56-4573-83e9-5debf097dabd"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(max=1),Scale(factor=0.1)"",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0e8946b7-939a-4299-9775-e10388d38e6f"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""LookToLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30839b70-ffd0-4a06-a705-adcdb233a053"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LookToLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9aa635ed-f679-4651-aaf8-66278b545645"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TakeDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ad34f4-4333-4a66-966a-73353d2853d8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""TakeDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Console"",
            ""id"": ""30b4534a-2714-4240-bd28-e70ecaa36e2e"",
            ""actions"": [
                {
                    ""name"": ""Show"",
                    ""type"": ""Button"",
                    ""id"": ""76a9319a-c9b4-4e0e-a638-a0e162639c63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""e38e6161-93d4-4fbd-8f90-16b663df9ee9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d024ed1-8157-4278-b75b-f2cce9056a47"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Show"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98c6039c-9673-4a58-9379-413a86318e32"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Show"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c0e00dd-f153-4abf-8ced-46bc133aad25"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""c381c2bb-2e59-4eba-8e0d-160a4a4dd11a"",
            ""actions"": [
                {
                    ""name"": ""Direction"",
                    ""type"": ""Button"",
                    ""id"": ""c1925a03-b3e9-4296-945a-d05e9885b563"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""e3db0665-a47e-43f8-a748-be45195eb624"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""e91ef4c3-d40e-4fa2-83bc-270c097c8b0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""33429603-1bb8-4397-abef-e3f7e41043a8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""080b4ee1-e3e3-4d55-a6d8-5bcb2d3369df"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2029075f-6b60-49c7-9fea-35298768fa53"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aedb4c58-3e4c-441d-ad69-8a07966e6373"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9651fbd5-e77d-4874-8fb4-71421b1af18d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c7ec73c3-9406-40ba-a71e-0a3c97822eb3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ecc7535-50c2-4a09-847d-0ef00787233d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c03c60c-c59e-411a-bd64-9200ffec2799"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f5306021-3c97-402a-868a-1835b13be1df"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9a514fe5-33a2-4e3f-a4a2-1dcd1fc56a27"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""DPad"",
                    ""id"": ""345d5271-17d8-4c79-ad3f-0149e61bcd38"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29d00ae8-b287-43a4-a444-102775648c5d"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5ab95a2c-bb5c-4860-968f-b453e888abfd"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""06fba6c6-a1c9-4b94-a7d8-4450079185f1"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a2099abc-52d7-4f2e-bc70-dadaa39a90cb"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0b927247-9ef1-489a-aeba-c09dc4ca3002"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44517260-080c-42cb-91aa-06bbe28d7a9d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""864bd8a5-bf1a-41ec-bdbe-8f863c0587bb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8d63330-26a0-438b-b86a-4c6cd8e57a21"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveKeyboard = m_Player.FindAction("MoveKeyboard", throwIfNotFound: true);
        m_Player_MoveGamepad = m_Player.FindAction("MoveGamepad", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Strike = m_Player.FindAction("Strike", throwIfNotFound: true);
        m_Player_Counter = m_Player.FindAction("Counter", throwIfNotFound: true);
        m_Player_LookToLock = m_Player.FindAction("LookToLock", throwIfNotFound: true);
        m_Player_TakeDown = m_Player.FindAction("TakeDown", throwIfNotFound: true);
        // Console
        m_Console = asset.FindActionMap("Console", throwIfNotFound: true);
        m_Console_Show = m_Console.FindAction("Show", throwIfNotFound: true);
        m_Console_Enter = m_Console.FindAction("Enter", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Direction = m_Game.FindAction("Direction", throwIfNotFound: true);
        m_Game_Click = m_Game.FindAction("Click", throwIfNotFound: true);
        m_Game_Escape = m_Game.FindAction("Escape", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveKeyboard;
    private readonly InputAction m_Player_MoveGamepad;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Strike;
    private readonly InputAction m_Player_Counter;
    private readonly InputAction m_Player_LookToLock;
    private readonly InputAction m_Player_TakeDown;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveKeyboard => m_Wrapper.m_Player_MoveKeyboard;
        public InputAction @MoveGamepad => m_Wrapper.m_Player_MoveGamepad;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Strike => m_Wrapper.m_Player_Strike;
        public InputAction @Counter => m_Wrapper.m_Player_Counter;
        public InputAction @LookToLock => m_Wrapper.m_Player_LookToLock;
        public InputAction @TakeDown => m_Wrapper.m_Player_TakeDown;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveKeyboard.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveKeyboard;
                @MoveKeyboard.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveKeyboard;
                @MoveKeyboard.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveKeyboard;
                @MoveGamepad.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveGamepad;
                @MoveGamepad.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveGamepad;
                @MoveGamepad.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveGamepad;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Strike.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrike;
                @Strike.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrike;
                @Strike.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrike;
                @Counter.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCounter;
                @Counter.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCounter;
                @Counter.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCounter;
                @LookToLock.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookToLock;
                @LookToLock.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookToLock;
                @LookToLock.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookToLock;
                @TakeDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTakeDown;
                @TakeDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTakeDown;
                @TakeDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTakeDown;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveKeyboard.started += instance.OnMoveKeyboard;
                @MoveKeyboard.performed += instance.OnMoveKeyboard;
                @MoveKeyboard.canceled += instance.OnMoveKeyboard;
                @MoveGamepad.started += instance.OnMoveGamepad;
                @MoveGamepad.performed += instance.OnMoveGamepad;
                @MoveGamepad.canceled += instance.OnMoveGamepad;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Strike.started += instance.OnStrike;
                @Strike.performed += instance.OnStrike;
                @Strike.canceled += instance.OnStrike;
                @Counter.started += instance.OnCounter;
                @Counter.performed += instance.OnCounter;
                @Counter.canceled += instance.OnCounter;
                @LookToLock.started += instance.OnLookToLock;
                @LookToLock.performed += instance.OnLookToLock;
                @LookToLock.canceled += instance.OnLookToLock;
                @TakeDown.started += instance.OnTakeDown;
                @TakeDown.performed += instance.OnTakeDown;
                @TakeDown.canceled += instance.OnTakeDown;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Console
    private readonly InputActionMap m_Console;
    private IConsoleActions m_ConsoleActionsCallbackInterface;
    private readonly InputAction m_Console_Show;
    private readonly InputAction m_Console_Enter;
    public struct ConsoleActions
    {
        private @InputManager m_Wrapper;
        public ConsoleActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Show => m_Wrapper.m_Console_Show;
        public InputAction @Enter => m_Wrapper.m_Console_Enter;
        public InputActionMap Get() { return m_Wrapper.m_Console; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConsoleActions set) { return set.Get(); }
        public void SetCallbacks(IConsoleActions instance)
        {
            if (m_Wrapper.m_ConsoleActionsCallbackInterface != null)
            {
                @Show.started -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnShow;
                @Show.performed -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnShow;
                @Show.canceled -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnShow;
                @Enter.started -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_ConsoleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Show.started += instance.OnShow;
                @Show.performed += instance.OnShow;
                @Show.canceled += instance.OnShow;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public ConsoleActions @Console => new ConsoleActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Direction;
    private readonly InputAction m_Game_Click;
    private readonly InputAction m_Game_Escape;
    public struct GameActions
    {
        private @InputManager m_Wrapper;
        public GameActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Direction => m_Wrapper.m_Game_Direction;
        public InputAction @Click => m_Wrapper.m_Game_Click;
        public InputAction @Escape => m_Wrapper.m_Game_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Direction.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDirection;
                @Click.started -= m_Wrapper.m_GameActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnClick;
                @Escape.started -= m_Wrapper.m_GameActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveKeyboard(InputAction.CallbackContext context);
        void OnMoveGamepad(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnStrike(InputAction.CallbackContext context);
        void OnCounter(InputAction.CallbackContext context);
        void OnLookToLock(InputAction.CallbackContext context);
        void OnTakeDown(InputAction.CallbackContext context);
    }
    public interface IConsoleActions
    {
        void OnShow(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnDirection(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
