﻿namespace DouYinFetch
{
    public enum MessageEnum
    {
        //消息
        WebcastChatMessage ,
        //成员进入
        WebcastMemberMessage ,
        //礼物
        WebcastGiftMessage,
        //房间排名
        WebcastRoomRankMessage,
        //房间状态
        WebcastRoomStatsMessage,
        //连麦通知
        WebcastLinkMicMethod,
        //连麦pk结束
        WebcastLinkMicBattleFinishMethod,
        //连麦通知
        LinkMicBattleMethod,
        //关注
        WebcastSocialMessage,
        //点赞
        WebcastLikeMessage,
        LiveEcomGeneralMessage,
        WebcastRoomBorderMessage,
        WebcastActivityInteractiveMessage,
        WebcastMagicGestureActivityMessage,
        WebcastRanklistHourEntranceMessage,
        WebcastPixActivityMessage,
        WebcastPrizeNoticeMessage,
        WebcastImageInfo,
        WebcastAdminPrivilegeMessage,
        WebcastAdminPrivilegeStruct,
        WebcastAdminRecordHandleMessage,
        WebcastAdminData,
        WebcastTextExtraItem,
        WebcastAdminRecordMessage,
        WebcastAnchorBoostMessage,
        WebcastAnchorBoost,
        WebcastAssetEffectUtilMessage,
        WebcastEffectUtilImageInfo,
        WebcastEffectUtilTextInfo,
        WebcastAssetMessage,
        WebcastAudioBGImgMessage,
        WebcastAudioChatMessage,
        WebcastAuthorizationNotifyMessage,
        WebcastAutoCoverMessage,
        WebcastAwemeShopExplainMessage,
        WebcastBackRecordVideoMessage,
        WebcastBattleCancelMessage,
        WebcastBattleFeedBackCardMessage,
        WebcastBattleFrontRankMessage,
        WebcastBattleInviteMessage,
        WebcastBattleModeMessage,
        WebcastBattleNotifyMessage,
        WebcastPrecisionMatch,
        WebcastBattlePrecisionMatchMessage,
        WebcastBattleRejectMessage,
        WebcastBattleTeamTaskAskMessage,
        WebcastBattleTeamTaskMessage,
        WebcastBattleUseCardMessage,
        WebcastBeginnerGuideMessage,
        WebcastLinkmicBigEventMessage,
        WebcastInitLinkmicContent,
        WebcastSwitchSceneContent,
        WebcastSwitchEarphoneMonitorContent,
        WebcastBridgeData,
        WebcastBridgeMessage,
        WebcastBrotherhoodMessage,
        WebcastCarBallShowMessage,
        WebcastCarSeriesInfoMessage,
        WebcastCategoryChangeMessage,
        WebcastChatCarnivalMessage,
        WebcastEggItem,
        WebcastChatItem,
        WebcastEmojiChatMessage,
        WebcastFriendChatMessage,
        WebcastCommentsMessage,
        WebcastCommerceMessage,
        WebcastCommerceSaleMessage,
        WebcastComplexContent,
        WebcastCommonGuideMessage,
        WebcastCommonLuckyMoneyMessage,
        WebcastTaskPanelMessage,
        WebcastTaskPanel,
        WebcastTaskRewardToastMessage,
        WebcastTaskRewardToast,
        WebcastCommonPopupMessage,
        WebcastCommonTextMessage,
        WebcastCommonToastMessage,
        WebcastControlMessage,
        WebcastDataLifeLiveMessage,
        WebcastDecorationModifyMessage,
        WebcastDiggMessage,
        WebcastDLiveMessage,
        WebcastOfficialRoomMessage,
        WebcastCeremonyMessage,
        WebcastUserRoom,
        WebcastRcmdUser,
        WebcastRecommendUsersMessage,
        WebcastDolphinSettingUpdateMessage,
        WebcastDonationMessage,
        WebcastDoodleGiftMessage,
        WebcastLikeUserDetail,
        WebcastDoubleLikeHeartMessage,
        WebcastDouplusIndicatorMessage,
        WebcastDouplusMessage,
        WebcastDriveGiftMessage,
        WebcastProjectDTaskInfo,
        WebcastDutyGiftMessage,
        WebcastEasterEggMessage,
        WebcastEasterEggMessageData,
        WebcastCornerReachMessage,
        WebcastTempStateAreaReachMessage,
        WebcastEpisodeChatMessage,
        WebcastFansGroupGuideMessage,
        WebcastFansclubStatisticsMessage,
        WebcastFansclubMessage,
        WebcastFansclubReviewMessage,
        WebcastFansclubGuideMessage,
        WebcastFeedbackActionMessage,
        WebcastFeedbackCardMessage,
        WebcastFollowGuideMessage,
        WebcastBrokerNotifyMessage,
        WebcastFreeCellGiftMessage,
        WebcastFreeGiftMessage,
        WebcastGamblingStatusChangedMessage,
        WebcastGameChannelMessage,
        WebcastHostVersion,
        WebcastGameAncAudEntranceMessage,
        WebcastGameAncAudStatusMessage,
        WebcastGameAncAudPanelCtrlMessage,
        WebcastGameAncAudDataFromAncMessage,
        WebcastGameAncAudDataFromAudMessage,
        WebcastGameDevelopMessage,
        WebcastGameGiftMessage,
        WebcastGameGiftStatusMessage,
        WebcastGameStatusMessage,
        WebcastGameInviteMessage,
        WebcastGameInviteReplyMessage,
        WebcastGamePVPMessage,
        WebcastGameStatusUpdateMessage,
        WebcastGameCPBaseMessage,
        WebcastGameCPShowMessage,
        WebcastReserveItem,
        WebcastGameCPUserDownloadMessage,
        WebcastGameCPAnchorReminderMessage,
        WebcastGamePlayTeamStatusMessage,
        WebcastGamePlayInviteMessage,
        WebcastGamePlayStatusMessage,
        WebcastLynxParam,
        WebcastGiftConsumeRemindMessage,
        WebcastGiftCycleReleaseMessage,
        WebcastExhibitionTopLeftMessage,
        WebcastExhibitionChatMessage,
        WebcastBindingGiftMessage,
        WebcastGiftUpdateMessage,
        WebcastGiftVoteMessage,
        WebcastGradeBuffAnchorShareMessage,
        WebcastGroupShowUserUpdateMessage,
        WebcastGrowthTaskMessage,
        WebcastGuestBattleMessage,
        WebcastGuestBattleScoreMessage,
        WebcastGuideMessage,
        WebcastHighlightComment,
        WebcastHighlightCommentPosition,
        WebcastHotChatMessage,
        WebcastHotRoomMessage,
        WebcastImDeleteMessage,
        WebcastInRoomBannerMessage,
        WebcastInRoomBannerEvent,
        WebcastInRoomBannerRedPoint,
        WebcastInRoomBannerRefreshMessage,
        WebcastOpenSchemaCommand,
        WebcastInstantCommandMessage,
        WebcastPopBoxContent,
        WebcastClientOperation,
        WebcastInteractControlMessage,
        WebcastInteractOpenDevelopMessage,
        WebcastIntercomInviteMessage,
        WebcastIntercomReplyMessage,
        WebcastEcomBuyIntentionMessage,
        WebcastKTVContestSupportMessage,
        WebcastKtvGrabSongResultMessage,
        WebcastKtvMessage,
        WebcastSetSettingOrderSongContent,
        WebcastAudienceOrderSongContent,
        WebcastAudienceOrderSongChatContent,
        WebcastPausePlaySongContent,
        WebcastKTVPlayModeStartMessage,
        WebcastKTVShortVideoCreatedMessage,
        WebcastKTVSingerHotRankPosMessage,
        WebcastKtvChallengeConfigMessage,
        WebcastKTVChallengeRankMessage,
        WebcastKTVChallengeStatusMessage,
        WebcastKTVStartGrabSongMessage,
        WebcastKTVUserSingingHotMessage,
        WebcastLevelUpMessage,
        WebcastDoubleLikeDetail,
        WebcastUserContribute,
        WebcastLinkerContributeMessage,
        WebcastLinkMessage,
        WebcastLinkmicInfo,
        WebcastLinkerSetting,
        WebcastLinkerInviteContent,
        WebcastLinkPrepareApplyContent,
        WebcastLinkerReplyContent,
        WebcastLinkerCreateContent,
        WebcastMatchEffect,
        WebcastCityEffect,
        WebcastLinkerEnterContent,
        WebcastLinkerViolationReminderContent,
        WebcastLinkerCloseContent,
        WebcastLinkerLeaveContent,
        WebcastLinkerCancelContent,
        WebcastLinkerKickOutContent,
        WebcastLinkerSysKickOutContent,
        WebcastLinkerWaitingListChangeContent,
        WebcastLinkerLinkedListChangeContent,
        WebcastLinkerBanContent,
        WebcastLinkerUpdateUserContent,
        WebcastChannelNoticeContent,
        WebcastLinkerItemContent,
        WebcastLinkerUpdateLinkTypeApplyContent,
        WebcastLinkerUpdateLinkTypeReplyContent,
        WebcastLinkerAvatarAuditContent,
        WebcastLinkerApplyExpiredContent,
        WebcastLinkerApplyStrongReminderContent,
        WebcastLinkerAnchorStreamSwitchContent,
        WebcastLinkerClickScreenContent,
        WebcastLinkerFollowStrongGuideContent,
        WebcastLinkerLockPositionContent,
        WebcastLinkerShareVideoImContent,
        WebcastLinkerGuestInviteContent,
        WebcastLinkerGuestExitCastScreenContent,
        WebcastLinkerSwitchSceneContent,
        WebcastLinkPhaseEnterNextNotifyContent,
        WebcastLinkerChangePlayModeContent,
        WebcastLinkerLowBalanceForPaidLinkmicContent,
        WebcastLinkerDegradeAlertContent,
        WebcastLinkerEnlargeGuestInviteContent,
        WebcastLinkerEnlargeGuestReplyContent,
        WebcastLinkerEnlargeGuestApplyContent,
        WebcastCrossRoomLinkInviteContent,
        WebcastCrossRoomLinkReplyContent,
        WebcastCrossRoomLinkCancelInviteContent,
        WebcastLinkerCrossRoomUpdateContent,
        WebcastLinkerChangeMultiPKTeamInfoContent,
        WebcastLinkerResumeAudienceContent,
        WebcastLinkerBattleConnectContent,
        WebcastLinkMicArmies,
        WebcastLinkMicArmiesMethod,
        WebcastLinkMicBattleMethod,
        WebcastLinkMicBattlePunishMethod,
        WebcastLinkMicBattleFinish,
        WebcastBattleMode,
        WebcastBattleSettings,
        WebcastBattleTask,
        WebcastLinkMicBattle,
        WebcastPunishEffect,
        WebcastLinkMicBattlePunish,
        WebcastLinkMicBattleTaskMessage,
        WebcastChijiNoticeMessage,
        WebcastLinkMicEnterNoticeMessage,
        WebcastLinkMicFriendOnlineMessage,
        WebcastLinkMicGuideMessage,
        WebcastLinkmicFollowEffectContent,
        WebcastGuestBattleBubbleGuideContent,
        WebcastCallToLinkmicContent,
        WebcastKtvAddSongGuideContent,
        WebcastCreateGroupChatGuideContent,
        WebcastJoinGroupChatGuideContent,
        WebcastCreateTeamfightGuideContent,
        WebcastNormalPaidLinkmicExplainCardContent,
        WebcastNormalPaidLinkmicMigrateToPlayContent,
        WebcastPKLinkBubbleContent,
        WebcastPlayModeGuideBubbleContent,
        WebcastLinkMicHostModifyMsg,
        WebcastLinkMicKtvBeatRankMessage,
        WebcastLinkMicKtvEffectMessage,
        WebcastLinkMicOChannelKickOutMsg,
        WebcastLinkMicOChannelNotifyMsg,
        WebcastLinkMicPositionMessage,
        WebcastLinkMicPositionListChangeContent,
        WebcastLinkMicPositionVerifyItem,
        WebcastLinkMicPositionVerifyContent,
        WebcastLinkMicSendEmojiMessage,
        WebcastLinkSettingNotifyMessage,
        WebcastPaiedOrTimeLimitChangeContent,
        WebcastLinkMicSignalingMethod,
        WebcastLinkMicAudienceKtvMessage,
        WebcastLinkmicProfitMessage,
        WebcastLinkmicProfitBidPaidLinkmicBidContent,
        WebcastLinkmicProfitBidPaidLinkmicDealContent,
        WebcastLinkmicProfitBidPaidLinkmicStartContent,
        WebcastLinkmicProfitBidPaidLinkmicAbortContent,
        WebcastLinkmicProfitBidPaidLinkmicTerminateContent,
        WebcastLinkmicProfitNormalPaidLinkmicOpenContent,
        WebcastLinkmicProfitNormalPaidLinkmicCloseContent,
        WebcastLinkmicProfitNormalPaidLinkmicConfigUpdateContent,
        WebcastLinkmicProfitNormalPaidLinkmicAddPriceContent,
        WebcastLinkmicProfitBidPaidLinkmicTurnOnContent,
        WebcastLinkmicProfitBidPaidLinkmicTurnOffContent,
        WebcastLinkmicRoomBattleInviteContent,
        WebcastLinkmicRoomBattleReplyContent,
        WebcastLinkmicReviewMessage,
        WebcastLinkmicReviewNormalPaidDescContent,
        WebcastLinkmicTeamfightMessage,
        WebcastLinkmicTeamfightFinishContent,
        WebcastLinkmicTeamfightScoreMessage,
        WebcastLinkmicOrderSingMessage,
        WebcastLinkmicOrderSingScoreMessage,
        WebcastLinkmicEcologyMessage,
        WebcastCouponActivityInfoMessage,
        WebcastCouponMetaInfoMessage,
        WebcastLiveEcomMessage,
        WebcastUpdatedProductInfo,
        WebcastUpdatedCouponInfo,
        WebcastUpdatedCampaignInfo,
        WebcastSkuInfo,
        WebcastTraceTimeMetric,
        WebcastUpdatedSkuInfo,
        WebcastUpdatedCommentaryVideoInfo,
        WebcastUpdatedGroupInfo,
        WebcastUserBid,
        WebcastImg,
        WebcastCurrentUserInfo,
        WebcastIncrPriceList,
        WebcastAuctionInfo,
        WebcastAuctionSuccess,
        WebcastRedpackActivityInfo,
        WebcastUpdatedCartInfo,
        WebcastBenefitLabel,
        WebcastHotAtmosphere,
        WebcastRoomTagOfflineInfo,
        WebcastLiveShoppingMessage,
        WebcastProductChangeMessage,
        WebcastProductInfo,
        WebcastCategoryInfo,
        WebcastLiveStreamControlMessage,
        WebcastMediaRoomNoticeMessage,
        WebcastMediaLiveReplayVidMessage,
        WebcastMotorCustomMessage,
        WebcastNabobImNoticeMessage,
        WebcastNobleEnterLeaveMessage,
        WebcastNobleToastMessage,
        WebcastNobleUpgradeMessage,
        WebcastNoticeMessage,
        WebcastNotifyEffectMessage,
        WebcastNotifyMessage,
        WebcastOChannelAnchorMessage,
        WebcastOChannelUserMessage,
        WebcastOChannelModifyMessage,
        WebcastPkActivePush,
        WebcastPkActivePushMessage,
        WebcastPKIconBubbleMessage,
        WebcastPKIconBubble,
        WebcastPopularCardMessage,
        WebcastPortalMessage,
        WebcastPortalBuy,
        WebcastPortalInvite,
        WebcastPortalFinish,
        WebcastPrivilegeScreenChatMessage,
        WebcastPrivilegeVoiceWaveMessage,
        WebcastProfileViewMessage,
        WebcastPromptMessage,
        WebcastPropertyNoticeMessage,
        WebcastPropsBGImgMessage,
        WebcastPullStreamUpdateMessage,
        WebcastPushMessage,
        WebcastWord,
        WebcastQuickComment,
        WebcastQuizStartMessage,
        WebcastQuizResult,
        WebcastQuizResultMessage,
        WebcastQuizChangeData,
        WebcastQuizChangeMessage,
        WebcastAllQuizInfo,
        WebcastQuizBeginMessage,
        WebcastQuizBetMessage,
        WebcastQuizAnchorStatusMessage,
        WebcastQuizAudienceStatusMessage,
        WebcastRankListAwardMessage,
        WebcastRankListHourEnterMessage,
        WebcastCreateRedPacketMessage,
        WebcastRushRedPacketMessage,
        WebcastRedPacketRushRecord,
        WebcastRedPacket,
        WebcastPushRoomAdCard,
        WebcastRoomAppConfigMessage,
        WebcastAnchorFaceConfig,
        WebcastRoomAuthInterventionVerifyMessage,
        WebcastRoomAuthMessage,
        WebcastRoomBackgroundMessage,
        WebcastRoomBottomMessage,
        WebcastRoomChallengeMessage,
        WebcastRoomConfigMessage,
        WebcastRoomDataSyncMessage,
        WebcastRoomHotSentenceMessage,
        WebcastRoomImgMessage,
        WebcastRoomIntroMessage,
        WebcastRoomManageMessage,
        WebcastRoomMessage,
        WebcastRoomStartMessage,
        WebcastRoomTicketMessage,
        WebcastRoomTopMessage,
        WebcastBackground,
        WebcastRoomUnionLiveMessage,
        WebcastRoomVerifyMessage,
        WebcastScreenChatMessage,
        WebcastShareGuideMessage,
        WebcastShortTouchAreaMessage,
        WebcastShowChatMessage,
        WebcastOfficialCommentConfig,
        WebcastCommentRoleConfig,
        WebcastShowEffectMessage,
        WebcastShowLinkedLiveRoomsMessage,
        WebcastShowMultiCameraChangeMessage,
        WebcastShowWatchInfoMessage,
        WebcastSpecialPushMessage,
        WebcastUpdateKoiRoomStatusMessage,
        WebcastStampMessage,
        WebcastAudienceEntranceMessage,
        WebcastCustomizedCardMessage,
        WebcastStreamControlMessage,
        WebcastSubscribeInfoMessage,
        WebcastSunDailyRankMessage,
        WebcastSyncStreamInfoMessage,
        WebcastSyncStreamMessage,
        WebcastSystemMessage,
        WebcastTaskMessage,
        WebcastToastMessage,
        WebcastToolBarControlMessage,
        WebcastBubbleConfig,
        WebcastToolbarItemBehaviourParam,
        WebcastToolbarItemBehaviourParams,
        WebcastToolbarItemMessage,
        WebcastTopLeftBubbleMessage,
        WebcastTurntableBurstMessage,
        WebcastAppointmentNumberUpdateMessage,
        WebcastUpdateFanTicketMessage,
        WebcastUploadCoverMessage,
        WebcastUpperRightWidgetDataMessage,
        WebcastUserPrivilegeChangeMessage,
        WebcastUserStatsMessage,
        WebcastVerificationCodeMessage,
        WebcastVIPInfoMessage,
        WebcastVIPSeatMessage,
        WebcastVsInteractiveMessage,
        WebcastVSLinkRoomMessage,
        WebcastVsPanelMessage,
        WebcastWebcastBattleBonusMessage,
        WebcastWebcastBattlePropertyMessage,
        WebcastInteractOpenAppStatusMessage,
        WebcastInteractOpenChatMessage,
        WebcastInteractOpenDiamondMessage,
        WebcastInteractOpenFollowingMessage,
        WebcastPerformanceFinishMessage,
        WebcastInteractOpenRewardMessage,
        WebcastInteractScreenshotMessage,
        WebcastInteractOpenViolationMessage,
        WebcastWebcastPopularCardMessage,
        WebcastWelfareProjectOperateMessage,
        WebcastWishFinishMessage,
        WebcastVideoLiveGoodsRcmdMessage,
        WebcastVideoLiveCouponRcmdMessage,
        WebcastVideoLiveGoodsOrderMessage,
        WebcastMatchHostChangeMessage,
        WebcastCommentaryChangeMessage,
        WebcastVsProgrammeStateControlMessage

    }

}