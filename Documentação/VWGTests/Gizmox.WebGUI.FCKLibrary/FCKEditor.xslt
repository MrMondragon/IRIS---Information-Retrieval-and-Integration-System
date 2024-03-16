<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Gizmox.WebGUI.FCKLibrary.FCKEditor" mode="modContent">
    <xsl:attribute name="Class">Common-FontData  FCKEditor-Control</xsl:attribute>
    <form id="{@ClientID}___Form" method="POST" vwgguid="{@Id}">
      <input type="hidden" id="{@ClientID}" name="{@UniqueID}" value="{@Attr.Value}"/>
      <input type="hidden" id="{@ClientID}___Config" value="{@Config}" />
      <iframe id="{@ClientID}___Frame" onload="mobjApp.FCKEditor_OnLoad(this,{@ClientID}___Form)" src="{@Attr.Source}" width="100%" height="100%" frameborder="no" allowtransparency="yes"  scrolling="no"></iframe>
    </form>
  </xsl:template>

</xsl:stylesheet>