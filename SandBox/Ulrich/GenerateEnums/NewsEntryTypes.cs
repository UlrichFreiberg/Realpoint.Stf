using System.ComponentModel.DataAnnotations;

public enum NewsEntryTypes
{

   /// <summary>
   /// Unknown
   /// </summary>
   [Display(Name = @"Unknown")]
   Unknown,

   /// <summary>
   /// baereredskab_oprettet
   /// </summary>
   [Display(Name = @"baereredskab_oprettet")]
   BaereredskabOprettet,

   /// <summary>
   /// baereredskab_genfundet
   /// </summary>
   [Display(Name = @"baereredskab_genfundet")]
   BaereredskabGenfundet,

   /// <summary>
   /// baereredskab_fortaelling
   /// </summary>
   [Display(Name = @"baereredskab_fortaelling")]
   BaereredskabFortaelling,

   /// <summary>
   /// baereredskab_paamarkedet
   /// </summary>
   [Display(Name = @"baereredskab_paamarkedet")]
   BaereredskabPaamarkedet,

   /// <summary>
   /// baereredskab_videregivet
   /// </summary>
   [Display(Name = @"baereredskab_videregivet")]
   BaereredskabVideregivet,

   /// <summary>
   /// baereredskab_omsyet
   /// </summary>
   [Display(Name = @"baereredskab_omsyet")]
   BaereredskabOmsyet,

   /// <summary>
   /// baereredskab_omsyet_gl
   /// </summary>
   [Display(Name = @"baereredskab_omsyet_gl")]
   BaereredskabOmsyetGl,

   /// <summary>
   /// baereredskab_omsyet_ny
   /// </summary>
   [Display(Name = @"baereredskab_omsyet_ny")]
   BaereredskabOmsyetNy,

   /// <summary>
   /// anmeldelse_vurdering
   /// </summary>
   [Display(Name = @"anmeldelse_vurdering")]
   AnmeldelseVurdering,

   /// <summary>
   /// anmeldelse_bedoemmelse
   /// </summary>
   [Display(Name = @"anmeldelse_bedoemmelse")]
   AnmeldelseBedoemmelse,

   /// <summary>
   /// anmeldelse_data
   /// </summary>
   [Display(Name = @"anmeldelse_data")]
   AnmeldelseData,

   /// <summary>
   /// traad_baereredskab
   /// </summary>
   [Display(Name = @"traad_baereredskab")]
   TraadBaereredskab,

   /// <summary>
   /// baereredskab_ferie
   /// </summary>
   [Display(Name = @"baereredskab_ferie")]
   BaereredskabFerie,

   /// <summary>
   /// baereredskab_udlejning
   /// </summary>
   [Display(Name = @"baereredskab_udlejning")]
   BaereredskabUdlejning,

   /// <summary>
   /// baereredskab_test
   /// </summary>
   [Display(Name = @"baereredskab_test")]
   BaereredskabTest,

   /// <summary>
   /// baereredskab_ferie_videresendt
   /// </summary>
   [Display(Name = @"baereredskab_ferie_videresendt")]
   BaereredskabFerieVideresendt,

   /// <summary>
   /// baereredskab_test_videresendt
   /// </summary>
   [Display(Name = @"baereredskab_test_videresendt")]
   BaereredskabTestVideresendt,

   /// <summary>
   /// baereredskab_ferie_fortaelling
   /// </summary>
   [Display(Name = @"baereredskab_ferie_fortaelling")]
   BaereredskabFerieFortaelling,

   /// <summary>
   /// baereredskab_test_fortaelling
   /// </summary>
   [Display(Name = @"baereredskab_test_fortaelling")]
   BaereredskabTestFortaelling,

   /// <summary>
   /// baereredskab_udlejning_fortaelling
   /// </summary>
   [Display(Name = @"baereredskab_udlejning_fortaelling")]
   BaereredskabUdlejningFortaelling,

   /// <summary>
   /// baereredskab_ferie_retur
   /// </summary>
   [Display(Name = @"baereredskab_ferie_retur")]
   BaereredskabFerieRetur,

   /// <summary>
   /// baereredskab_udlejning_retur
   /// </summary>
   [Display(Name = @"baereredskab_udlejning_retur")]
   BaereredskabUdlejningRetur,

   /// <summary>
   /// baereredskab_test_retur
   /// </summary>
   [Display(Name = @"baereredskab_test_retur")]
   BaereredskabTestRetur,
}
