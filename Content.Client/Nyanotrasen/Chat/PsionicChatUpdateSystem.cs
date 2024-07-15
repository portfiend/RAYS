using Content.Client.Chat.Managers;
using Robust.Client.Player;
using Content.Shared.Rays.Abilities.Components;

namespace Content.Client.Nyanotrasen.Chat
{
    public sealed class PsionicChatUpdateSystem : EntitySystem
    {
        [Dependency] private readonly IChatManager _chatManager = default!;
        [Dependency] private readonly IPlayerManager _playerManager = default!;

        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<TelepathComponent, ComponentInit>(OnInit);
            SubscribeLocalEvent<TelepathComponent, ComponentRemove>(OnRemove);
        }

        public TelepathComponent? Player => CompOrNull<TelepathComponent>(_playerManager.LocalPlayer?.ControlledEntity);
        public bool IsPsionic => Player != null;

        private void OnInit(EntityUid uid, TelepathComponent component, ComponentInit args)
        {
            _chatManager.UpdatePermissions();
        }

        private void OnRemove(EntityUid uid, TelepathComponent component, ComponentRemove args)
        {
            _chatManager.UpdatePermissions();
        }
    }
}
